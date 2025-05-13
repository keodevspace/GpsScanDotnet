import emailjs from '@emailjs/nodejs';

export default async function handler(req, res) {
  if (req.method !== 'POST') {
    return res.status(405).json({ message: 'Method not allowed' });
  }

  const { latitude, longitude, map_link } = req.body;

  try {
    const result = await emailjs.send(
      process.env.EMAILJS_SERVICE_ID,
      process.env.EMAILJS_TEMPLATE_ID,
      { latitude, longitude, map_link },
      {
        publicKey: process.env.EMAILJS_PUBLIC_KEY,
        privateKey: process.env.EMAILJS_PRIVATE_KEY
      }
    );
    console.error('EmailJS error:', error);
    res.status(200).json({ message: 'Email sent!', result });
  } catch (error) {
    console.error('EmailJS error:', error);
    res.status(500).json({ message: 'Error sending email.', error });
  }
}