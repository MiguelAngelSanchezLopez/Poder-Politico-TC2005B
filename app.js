const express = require('express');
const app = express();

const PORT = process.env.PORT || 3000;
app.get('/', (req, res) => {
  res.send('Hello, this is my Express server!');
});
app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});

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