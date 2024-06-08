const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');
const morgan = require('morgan');
const { Connection, Request, TYPES } = require('tedious');

const app = express();
const PORT = process.env.PORT || 3000;
const { GoogleGenerativeAI } = require("@google/generative-ai");
const fs = require("fs");
const API_KEY = 'AIzaSyCtn7lNbzVQusWCB3WCxz66FkQkCxA8Shs'
// Access your API key as an environment variable (see "Set up your API key" above)
const genAI = new GoogleGenerativeAI(API_KEY);

// Middleware
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());
app.use(cors());
app.use(morgan('dev'));

// Test route
app.get('/', (req, res) => {
  res.send('Hello, this is my Express server!');
});

// MS SQL Server configuration
var config = require('tedious').Connection;  
    var dbConfig = {  
        server: 'basedatospoliticalpower.database.windows.net',  
        authentication: {
            type: 'default',
            options: {
                userName: 'administrador', 
                password: 'Te$91827364'  
            }
        },
        options: {
            // Microsoft Azure so we need encryption:
            //encrypt: true,
            database: 'PoliticalPowerDataBase'
        }
    }; 

var connection = new Connection(dbConfig);  
connection.on('connect', function(err) {  
    // If no error, then good to proceed.  
    console.log("Connected");  
    // executeStatement();  
}); 

connection.connect();

// Login route
app.post('/api/login', (req, res) => {
  const { email, password } = req.body;

  const connection = new Connection(dbConfig);

  connection.on('connect', (err) => {
    if (err) {
      console.error('Database connection error:', err);
      return res.status(500).json({ message: 'Internal server error' });
    }

    const query = 'SELECT * FROM Usuarios WHERE correo = @correo AND contrasenia = @contrasenia';
    const request = new Request(query, (err, rowCount, rows) => {
      if (err) {
        console.error('SQL error:', err);
        return res.status(500).json({ message: 'Internal server error' });
      }
      
      if (rowCount > 0) {
        res.json({ message: 'Login successful' });
      } else {
        res.status(401).json({ message: 'Invalid email or password' });
      }
      connection.close();
    });

    request.addParameter('correo', TYPES.VarChar, email);
    request.addParameter('contrasenia', TYPES.VarChar, password);

    connection.execSql(request);
  });

  connection.connect();
});

// Register route
app.post('/api/register', (req, res) => {
  const { name, email, password } = req.body;

  const connection = new Connection(dbConfig);

  connection.on('connect', (err) => {
    if (err) {
      console.error('Database connection error:', err);
      return res.status(500).json({ message: 'Internal server error' });
    }

    const query = 'INSERT INTO Usuarios (nombre, contrasenia, correo) VALUES ( @nombre, @contrasenia, @correo) ';
    const request = new Request(query, (err) => {
      if (err) {
        console.error('SQL error:', err);
        return res.status(500).json({ message: 'Internal server error' });
      }

      res.json({ message: 'Registration successful' });
      connection.close();
    });

    request.addParameter('nombre', TYPES.VarChar, name);
    request.addParameter('correo', TYPES.VarChar, email);
    request.addParameter('contrasenia', TYPES.VarChar, password);

    connection.execSql(request);
  });

  connection.connect();
});

// Add a new endpoint to fetch data from the database into AI component
app.get('/api/chartdata', (req, res) => {
  const query = 'SELECT CandidatosPresidenciales.nombreCandidato AS nombre_candidato FROM EleccionCandidatos JOIN CandidatosPresidenciales ON EleccionCandidatos.idCandidato = CandidatosPresidenciales.idCandidato'; 

  const connection = new Connection(dbConfig);

    connection.on('connect', (err) => {
        if (err) {
            console.error('Database connection error:', err);
            return res.status(500).json({ message: 'Internal server error' });
        }

        const request = new Request(query, (err, rowCount, rows) => {
            if (err) {
                console.error('SQL error:', err);
                return res.status(500).json({ message: 'Internal server error' });
            }

            const data = rows.map(row => ({
                label: row[0].value, // Adjust index based on your query result
                value: row[1].value // Adjust index based on your query result
            }));

            res.json(data);
            connection.close();
        });

        connection.execSql(request);
    });

    connection.connect();
});

// Converts local file information to a GoogleGenerativeAI.Part object.
function fileToGenerativePart(path, mimeType) {
  return {
    inlineData: {
      data: Buffer.from(fs.readFileSync(path)).toString("base64"),
      mimeType
    },
  };
}

async function run() {
  // The Gemini 1.5 models are versatile and work with both text-only and multimodal prompts
  const model = genAI.getGenerativeModel({ model: "gemini-1.5-flash" });

  const prompt = "What's different between these pictures?";

  const imageParts = [
    fileToGenerativePart('/Users/miguelangelsanchezlopez/Documents/GitHub/Poder-Politico-TC2005B/src/images/candidata-fuerzycorazonxmexico-xochitl-presidencial.jpg', "image/jpg"),
    fileToGenerativePart('/Users/miguelangelsanchezlopez/Documents/GitHub/Poder-Politico-TC2005B/src/images/candidata-morena-sheinbaum-presidencial.jpg', "image/jpg"),
    fileToGenerativePart('/Users/miguelangelsanchezlopez/Documents/GitHub/Poder-Politico-TC2005B/src/images/candidato-mc-maynez-presidencial.jpg', "image/jpg")
  ];

  const result = await model.generateContent([prompt, ...imageParts]);
  const response = await result.response;
  const text = response.text();
  console.log(text);
}

run();

// Endpoint to interpret multiple images and return the result
app.post('/api/interpret-images', async (req, res) => {
  try {
      const { imagePaths, prompt } = req.body;
      
      const model = genAI.getGenerativeModel({ model: "gemini-1.5-flash" });

      const imageParts = imagePaths.map(imagePath => {
          const imageBuffer = fs.readFileSync(imagePath);
          const imageBase64 = Buffer.from(imageBuffer).toString('base64');
          return {
              inlineData: {
                  data: imageBase64,
                  mimeType: 'image/jpg', // Adjust according to your image type
              },
          };
      });

      const result = await model.generateContent([prompt, ...imageParts]);
      const text = await result.response.text();
      
      res.json({ text });
  } catch (error) {
      console.error('Error interpreting images:', error);
      res.status(500).json({ message: 'Error interpreting images', error: error.message });
  }
});


// Start the server
app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});