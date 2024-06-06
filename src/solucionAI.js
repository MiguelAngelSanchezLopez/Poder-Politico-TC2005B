import React from 'react';

function interpretacionGrafica() {
    const anthropic = require('anthropic-sdk');

    const client = new anthropic.Client('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');

    const imageUrl = 'https://upload.wikimedia.org/wikipedia/commons/d/de/World_population_pie_chart.JPG';

    client.interpretGraph(imageUrl)
    .then(response => {
    console.log(response);
    // Procesa la respuesta y realiza acciones adicionales
  })
  .catch(error => {
    console.error('Error al interpretar el gráfico:', error);
  });
    return (
        <div>
            <h1>Hola, mundo!</h1>
        </div>
    );
}

export default interpretacionGrafica;