using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject[] maps;



    void Start()
    {
        int index = Random.Range(0, maps.Length);

        // Spawn the map
        Instantiate(maps[index], new Vector3(390.7f, 166.4f, 0f), Quaternion.identity);
        Debug.Log("Loaded map: " + maps[index].name);

        // Spawn chests for this map
        SpawnChests(index + 1);
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


}
