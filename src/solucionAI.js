// src/solucionAI.js
import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Line } from 'react-chartjs-2';

function InterpretacionGrafica() {
    const [chartData, setChartData] = useState({});
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
            try {
                // Obtener datos de la base de datos desde tu backend
                const dbResponse = await axios.get('http://localhost:3000/api/chartdata');
                const dbData = dbResponse.data.data;

                // Check if dbData is an array and has data
                if (!Array.isArray(dbData) || dbData.length === 0) {
                    throw new Error('No data available');
                }

                const requestData = {
                    values: dbData.map(item => item.value),
                    labels: dbData.map(item => item.label)
                };

                // Enviar datos a la API de Gemini para interpretación
                const geminiResponse = await axios.post('https://api.gemini.com/v1/interpret', {
                    apiKey: process.env.REACT_APP_GEMINI_API_KEY, // Use environment variable
                    data: requestData
                });

                const interpretedData = geminiResponse.data;

                // Check if interpretedData has labels and values
                if (!interpretedData.labels || !interpretedData.values) {
                    throw new Error('Interpreted data is incomplete');
                }

                // Configurar los datos para el gráfico
                const data = {
                    labels: interpretedData.labels, // Use interpreted labels
                    datasets: [
                        {
                            label: 'Resultados Interpretados',
                            data: interpretedData.values, // Use interpreted values
                            backgroundColor: 'rgba(75,192,192,0.4)',
                            borderColor: 'rgba(75,192,192,1)',
                            borderWidth: 1,
                        }
                    ]
                };

                setChartData(data);
            } catch (error) {
                console.error('Error fetching data:', error);
                setError(error.message);
            } finally {
                setLoading(false);
            }
        };

        fetchData();
    }, []);

    if (loading) {
        return <div><h1>Interpretación de Gráfica</h1><p>Cargando...</p></div>;
    }

    if (error) {
        return <div><h1>Interpretación de Gráfica</h1><p>Error: {error}</p></div>;
    }

    return (
        <div>
            <h1>Interpretación de Gráfica</h1>
            <Line data={chartData} />
        </div>
    );
}

export default InterpretacionGrafica;
