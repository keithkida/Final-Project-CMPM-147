using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject[] maps;
    [SerializeField] public Transform[] bossEntrances;
    [SerializeField] public GameObject bossDoorPrefab;




    void Start()
    {
        int index = Random.Range(0, maps.Length);

        // Spawn the map
        Instantiate(maps[index], new Vector3(390.7f, 166.4f, 0f), Quaternion.identity);
        Debug.Log("Loaded map: " + maps[index].name);

        // Spawn chests for this map
        SpawnChests(index + 1);

        bossDoorPrefab.transform.position = bossEntrances[index].position;

        SpawnPlayer();

    }

    void SpawnChests(int mapIndex)
    {
        ChestSpawnPoint[] points = FindObjectsByType<ChestSpawnPoint>(FindObjectsSortMode.None);
        ChestType[] chests = FindObjectsByType<ChestType>(FindObjectsSortMode.None);

        foreach (ChestSpawnPoint p in points)
        {
            if (p.mapIndex == mapIndex)
            {
                foreach (ChestType chest in chests)
                {
                    if (chest.chestType == p.chestType)
                    {
                        chest.transform.position = p.transform.position;
                    }
                }
            }
        }
    }

    void SpawnPlayer()
    {
        PlayerSpawnPoint point = FindFirstObjectByType<PlayerSpawnPoint>();

        if (point != null)
        {
            var player = FindFirstObjectByType<PlayerStats>();
            if (player != null)
            {
                player.transform.position = point.transform.position;
                return;
            }
        }

        Debug.LogWarning("No PlayerSpawnPoint found!");

    }
}