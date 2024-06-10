import React, { useState, useEffect } from 'react';
import axios from 'axios';

// Import images as modules
import Xochitl from '../src/images/candidata-fuerzycorazonxmexico-xochitl-presidencial.jpg';
import Claudia from '../src/images/candidata-morena-sheinbaum-presidencial.jpg';
import Maynez from '../src/images/candidato-mc-maynez-presidencial.jpg';
//import PieChart from '../src/images/Pie-Charts.jpg';

const InterpretacionGrafica = () => {
  const [responseText, setResponseText] = useState('');
  const [text, setText] = useState('');
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const interpretImages = async () => {
      try {
        // Simulate AI interpretation response (replace with actual logic if needed)
        const interpretedText = "The AI interpreted the images.";
        const response = await fetch('http://localhost:3000/api/interpret-images', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ text }),
        });

        const data = await response.json();


        // Update state with interpreted text
        setResponseText(text);
        setLoading(false);
      } catch (error) {
        setLoading(false);
        setError(`Error interpreting images: ${error.message}`);
      }
    };

    interpretImages();
  }, []);

  if (loading) return <div>Loading...</div>;
  if (error) return <div>Error: {error}</div>;

  return (
    <div>
      <h1>Interpretación Gráfica</h1>
      
      {/* Display imported images */}
      <div>
        <img src={Xochitl} alt="Xochitl" style={{ width: '200px', height: 'auto', marginRight: '10px' }} />
        <img src={Claudia} alt="Claudia" style={{ width: '200px', height: 'auto', marginRight: '10px' }} />
        <img src={Maynez} alt="Maynez" style={{ width: '200px', height: 'auto', marginRight: '10px' }} />
        {/* <img src={PieChart} alt="Pie Chart" style={{ width: '200px', height: 'auto' }} /> */}
      </div>

      <p>{responseText}</p>
    </div>
  );
};

export default InterpretacionGrafica;
