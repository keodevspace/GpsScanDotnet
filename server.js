const express = require('express');
const bodyParser = require('body-parser');
const emailjs = require('@emailjs/nodejs'); 

const app = express();
app.use(bodyParser.json());

app.post('/api/send-location', async (req, res) => {
  const { latitude, longitude, map_link } = req.body;

  try {
    const result = await emailjs.send(
      process.env.EMAILJS_SERVICE_ID,   
      process.env.EMAILJS_TEMPLATE_ID,  
      {
        latitude,
        longitude,
        map_link
      },
      {
        publicKey: process.env.EMAILJS_PUBLIC_KEY, 
        privateKey: process.env.EMAILJS_PRIVATE_KEY 
      }
    );

    res.status(200).json({ message: 'Email sent!', result });
  } catch (error) {
    res.status(500).json({ message: 'Error sending email.', error });
  }
});