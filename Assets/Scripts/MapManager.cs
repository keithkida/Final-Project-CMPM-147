using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject[] maps;

    void Start()
    {
        int index = Random.Range(0, maps.Length);
        Instantiate(maps[index], new Vector3(390.7f, 166.4f, 0f), Quaternion.identity);
        Debug.Log("Loaded map: " + maps[index].name);
    }
}
