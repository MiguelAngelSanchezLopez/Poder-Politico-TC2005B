import React, { useState, useEffect } from 'react';
import axios from 'axios';

const InterpretacionGrafica = () => {
    const [responseText, setResponseText] = useState('');
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const interpretImages = async () => {
            try {
                const IMAGE_PATHS = [
                    '/Users/miguelangelsanchezlopez/Documents/GitHub/Poder-Politico-TC2005B/src/images/candidata-fuerzycorazonxmexico-xochitl-presidencial.jpg',
                    '/Users/miguelangelsanchezlopez/Documents/GitHub/Poder-Politico-TC2005B/src/images/candidata-morena-sheinbaum-presidencial.jpg',
                    '/Users/miguelangelsanchezlopez/Documents/GitHub/Poder-Politico-TC2005B/src/images/candidato-mc-maynez-presidencial.jpg',
                    '/Users/miguelangelsanchezlopez/Documents/GitHub/Poder-Politico-TC2005B/src/images/Pie-Charts.jpg'
                ]; // Ajusta las rutas según sea necesario
                const PROMPT = "What can you interpret from the pie chart?";

                // Realizar la solicitud a tu backend para interpretar las imágenes
                const response = await axios.post(
                    'http://localhost:3000/api/interpret-images', // Asegúrate de que la URL coincida con tu configuración del servidor
                    {
                        imagePaths: IMAGE_PATHS,
                        prompt: PROMPT,
                    }
                );

                setResponseText(response.data.text);
                setLoading(false);
            } catch (error) {
                setLoading(false);
                if (error.response) {
                    // El servidor respondió con un estado fuera del rango 2xx
                    setError(`Error en la respuesta del servidor: ${error.response.data.message}`);
                } else if (error.request) {
                    // La solicitud fue hecha pero no se recibió respuesta
                    setError('No se recibió respuesta del servidor.');
                } else {
                    // Algo sucedió al configurar la solicitud que desencadenó un error
                    setError(`Error al configurar la solicitud: ${error.message}`);
                }
            }
        };

        interpretImages();
    }, []);

    return (
        <div>
            <h1>Interpretación de Gráfica</h1>
            {loading ? <p>Cargando...</p> : error ? <p>Error: {error}</p> : (
                <>
                    <img src="./src/images/Pie-Charts.jpg" alt="Pie Chart" />
                    <p>{responseText}</p>
                </>
            )}
        </div>
    );
};

export default InterpretacionGrafica;




