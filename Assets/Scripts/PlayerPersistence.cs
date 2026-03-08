using UnityEngine;

public class PlayerPersistence : MonoBehaviour
{
    void Awake()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}
