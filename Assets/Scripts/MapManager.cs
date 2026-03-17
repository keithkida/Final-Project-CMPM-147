using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject[] maps;
    [SerializeField] public Transform[] bossEntrances;
    [SerializeField] public GameObject bossDoorPrefab;
    [SerializeField] private GameObject[] orbPrefabs;
    [SerializeField] private GameObject breakableStonePrefab;
    [SerializeField] private GameObject pickaxePrefab;


    void Start()
    {
        int index = Random.Range(0, maps.Length);

        // Spawn the map
        Instantiate(maps[index], new Vector3(441.9496f, 199.3458f, 0f), Quaternion.identity);
        Debug.Log("Loaded map: " + maps[index].name);

        // Spawn chests for this map
        SpawnChests(index + 1);

        bossDoorPrefab.transform.position = bossEntrances[index].position;

        SpawnPlayer(index + 1);

        SpawnOrbs(index + 1);

        SpawnPickaxe(index + 1);

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

    void SpawnPlayer(int mapIndex)
    {
        PlayerSpawnPoint[] points = FindObjectsByType<PlayerSpawnPoint>(FindObjectsSortMode.None);

        foreach (var point in points)
        {
            if (point.mapIndex == mapIndex)
            {
                var player = FindFirstObjectByType<PlayerStats>();
                if (player != null)
                {
                    player.transform.position = point.transform.position;
                    return;
                }
            }
        }

        Debug.LogWarning("No matching PlayerSpawnPoint found!");
    }

void SpawnOrbs(int mapIndex)
{
    OrbSpawnPoint[] points = FindObjectsByType<OrbSpawnPoint>(FindObjectsSortMode.None);

    foreach (var point in points)
    {
        if (point.mapIndex == mapIndex)
        {
            int index = Random.Range(0, orbPrefabs.Length);

            GameObject orb = Instantiate(orbPrefabs[index], point.transform.position, Quaternion.identity);
            orb.SetActive(false);

            GameObject stone = Instantiate(breakableStonePrefab, point.transform.position, Quaternion.identity);
            
            BreakableStone bs = stone.GetComponent<BreakableStone>();
            bs.orbBehindStone = orb;
        }
    }
}


    void SpawnPickaxe(int mapIndex)
    {
        PickaxeSpawnPoint[] points = FindObjectsByType<PickaxeSpawnPoint>(FindObjectsSortMode.None);

        foreach (var point in points)
        {
            if (point.mapIndex == mapIndex)
            {
                Instantiate(pickaxePrefab, point.transform.position, Quaternion.identity);
                return; 
            }
        }

        Debug.LogWarning("No PickaxeSpawnPoint found for map " + mapIndex);
    }


}