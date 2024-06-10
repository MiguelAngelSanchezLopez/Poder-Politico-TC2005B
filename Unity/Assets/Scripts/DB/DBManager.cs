using System;
using MySql.Data.MySqlClient;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    private string server = "your_server_address";
    private string database = "your_database_name";
    private string username = "your_username";
    private string password = "your_password";
    
    private string connectionString;

    void Start()
    {
        connectionString = $"Server={server};Database={database};User ID={username};Password={password};Pooling=true;";

        string playerName = "UpdatedPlayerName"; // Replace with the actual player name
        int playerId = 1; // Replace with the actual player ID you want to update
        UpdatePlayerName(playerId, playerName);
    }

    public void UpdatePlayerName(int playerId, string playerName)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Debug.Log("MySQL Connection Opened Successfully.");

                string query = "UPDATE Player SET PlayerName = @PlayerName WHERE Id = @Id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PlayerName", playerName);
                    command.Parameters.AddWithValue("@Id", playerId);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        Debug.Log("Player name updated successfully!");
                    }
                    else
                    {
                        Debug.LogError("Failed to update player name.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("MySQL Error: " + ex.Message);
            }
        }
    }
}
