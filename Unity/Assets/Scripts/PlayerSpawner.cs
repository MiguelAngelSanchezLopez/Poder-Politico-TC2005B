using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public Transform spawnPoint; // Reference to the spawn point Transform

    void Start()
    {
        // Check if the player has spawned before
        if (!PlayerPrefs.HasKey("HasPlayerSpawned"))
        {
            // Spawn the player at the spawn point
            if (player != null && spawnPoint != null)
            {
                player.transform.position = spawnPoint.position;
                PlayerPrefs.SetInt("HasPlayerSpawned", 1); // Set flag indicating the player has spawned
            }
            else
            {
                Debug.LogError("Player or Spawn Point is not assigned in PlayerSpawner script.");
            }
        }
        else
        {
            // Load the player's previous position if available
            float playerPosX = PlayerPrefs.GetFloat("PlayerPosX", player.transform.position.x);
            float playerPosY = PlayerPrefs.GetFloat("PlayerPosY", player.transform.position.y);

            playerPosY -= 1.0f;
            player.transform.position = new Vector3(playerPosX, playerPosY, player.transform.position.z);
        }
    }


    void OnDisable()
    {
        SavePlayerPosition();
    }

    void SavePlayerPosition()
    {
        if (player != null)
        {
            PlayerPrefs.SetFloat("PlayerPosX", player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", player.transform.position.y);
        }
    }
}