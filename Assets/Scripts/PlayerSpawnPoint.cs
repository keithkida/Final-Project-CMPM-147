using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    void Start()
    {
        // Find the SpawnPoint in the loaded map
        SpawnPoint spawn = FindFirstObjectByType<SpawnPoint>();

        if (spawn == null)
        {
            Debug.LogError("No SpawnPoint found in the loaded map!");
            return;
        }

        // Move the player to the spawn point
        transform.position = spawn.transform.position;
    }
}
