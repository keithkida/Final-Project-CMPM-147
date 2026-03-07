using UnityEngine;

public class Map : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject playerPrefab;

    void Start()
    {
        Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
    }
}
