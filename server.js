const express = require('express');
const app = express();

const sql = require('mssql');

const PORT = process.env.PORT || 3000;
app.get('/', (req, res) => {
  res.send('Hello, this is my Express server!');
});
app.listen(PORT, () => {
  console.log(`Server is running on port ${3000}`);
});

const bodyParser = require('body-parser');
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

const cors = require('cors');
app.use(cors());

const morgan = require('morgan');
app.use(morgan('dev'));

// app.use('/api', apiRoutes);

var Connection = require('tedious').Connection;  
    var config = {  
        server: 'basedatospoliticalpower.database.windows.net',  
        authentication: {
            type: 'default',
            options: {
                userName: 'administrador', //update me
                password: 'Te$91827364'  //update me
            }
        },
        options: {
            // If you are on Microsoft Azure, you need encryption:
            encrypt: true,
            database: 'PoliticalPowerDataBase'  //update me
        }
    }; 
    
    var connection = new Connection(config);  
    connection.on('connect', function(err) {  
        // If no error, then good to proceed.  
        console.log("Connected");  
        // executeStatement();  
    });  
    
    connection.connect();


    var Request = require('tedious').Request;  
    var TYPES = require('tedious').TYPES;  
  
    function executeStatement() {  
        var request = new Request("EXEC getall_candidatos;", function(err) {  
        if (err) {  
            console.log(err);}  
        });  
        var result = "";  
        request.on('row', function(columns) {  
            columns.forEach(function(column) {  
              if (column.value === null) {  
                console.log('NULL');  
              } else {  
                result+= column.value + " ";  
              }  
            });  
            console.log(result);  
            result ="";  
        });  
  
        request.on('done', function(rowCount, more) {  
        console.log(rowCount + ' rows returned');  
        });  
        
        // Close the connection after the final event emitted by the request, after the callback passes
        request.on("requestCompleted", function (rowCount, more) {
            connection.close();
        });
        connection.execSql(request);  
    }
// Logn route
app.post('/src/Login.js', async (req, res) => {
  const { email, password } = req.body;

  try {
      let pool = await sql.connect(dbConfig);
      let result = await pool.request()
          .input('email', sql.VarChar, email)
          .input('password', sql.VarChar, password) // Consider hashing passwords
          .query('SELECT * FROM Users WHERE email = @email AND password = @password');

      if (result.recordset.length > 0) {
          res.json({ message: 'Login successful' });
      } else {
          res.status(401).json({ message: 'Invalid email or password' });
      }
  } catch (err) {
      console.error('Database connection error:', err);
      res.status(500).json({ message: 'Internal server error' });
  }
});

// Start the server
app.listen(port, () => {
  console.log(`Server running on http://localhost:${3000}`);
});