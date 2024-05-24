const express = require('express');
const app = express();

const PORT = process.env.PORT || 3000;
app.get('/', (req, res) => {
  res.send('Hello, this is my Express server!');
});
app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});

// TODO: DATABASE CONFIGURATION
/*
const config = {
    user: 'your_username',
    password: 'your_password',
    // Notice public keyword in the connection string 
    // if you were to host this server on Azure you wouldn't need the public part
    server: 'free-sql-mi.public.daff4276.database.windows.net',
    database: 'ticket-app',
    options: {
      // THIS IS VERY IMPORTANT - Public endpoint is 3342, default is 1443
      port: 3342, 
      encrypt: true,
    },
  };
  // Connect to the database
  sql.connect(config, (err) => {
    if (err) {
      console.error('Database connection failed:', err);
    } else {
      console.log('Connected to the database');
    }
  });
 */

  // Server response and console log messages
  app.get('/', (req, res) => {
    res.send('Hello, this is my Express server!');
  });
  app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
  });
 
const bodyParser = require('body-parser');
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

const cors = require('cors');
app.use(cors());

const morgan = require('morgan');
app.use(morgan('dev'));

// app.use('/api', apiRoutes);