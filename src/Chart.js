import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Bar } from 'react-chartjs-2';

const Chart = () => {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get('http://localhost:3001/api/data');
        setData(response.data);
        setLoading(false);
      } catch (error) {
        setLoading(false);
        setError('Error fetching data');
      }
    };

    fetchData();
  }, []);

  if (loading) return <div>Loading...</div>;
  if (error) return <div>Error: {error}</div>;

  // Prepare data for chart
  const chartData = {
    labels: data.map(row => row.ApellidoCandidato),
    datasets: [
      {
        label: 'Total Votes',
        backgroundColor: 'rgba(75,192,192,0.2)',
        borderColor: 'rgba(75,192,192,1)',
        borderWidth: 1,
        hoverBackgroundColor: 'rgba(75,192,192,0.4)',
        hoverBorderColor: 'rgba(75,192,192,1)',
        data: data.map(row => row.TotalVotos)
      }
    ]
  };

  return (
    <div>
      <h1>Data Table and Column Chart</h1>

      {/* Column Chart */}
      <div style={{ height: '400px', marginBottom: '20px' }}>
        <Bar
          data={chartData}
          options={{
            maintainAspectRatio: false,
            scales: {
              yAxes: [{
                ticks: {
                  beginAtZero: true
                }
              }]
            }
          }}
        />
      </div>

      {/* Data Table */}
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Total Votes</th>
          </tr>
        </thead>
        <tbody>
          {data.map((row, index) => (
            <tr key={index}>
              <td>{row.ApellidoCandidato}</td>
              <td>{row.TotalVotos}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Chart;
