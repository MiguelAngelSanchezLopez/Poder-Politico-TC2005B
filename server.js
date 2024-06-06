const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');
const morgan = require('morgan');
const { Connection, Request, TYPES } = require('tedious');

const app = express();

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
const dbConfig = {
  server: 'basedatospoliticalpower.database.windows.net',
  authentication: {
    type: 'default',
    options: {
      userName: 'administrador',
      password: 'Te$91827364'
    }
  },
  options: {
    encrypt: true,
    database: 'PoliticalPowerDataBase'
  }
};

const connection = new Connection(dbConfig);
connection.on('connect', (err) => {
  if (err) {
    console.error('Database connection error:', err);
  } else {
    console.log('Connected');
  }
});

connection.connect();

// Login route
app.post('http://poder-politico-tc-2005-b-8dy6.vercel.app/api/login', (req, res) => {
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
app.post('http://poder-politico-tc-2005-b-8dy6.vercel.app/api/register', (req, res) => {
  const { name, email, password } = req.body;

  const connection = new Connection(dbConfig);
  connection.on('connect', (err) => {
    if (err) {
      console.error('Database connection error:', err);
      return res.status(500).json({ message: 'Internal server error' });
    }

    const query = 'INSERT INTO Usuarios (nombre, contrasenia, correo) VALUES (@nombre, @contrasenia, @correo)';
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

module.exports = app;
