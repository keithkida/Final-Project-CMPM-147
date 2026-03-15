using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadowFollow : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        // If player reference is missing, try to find a new one
        if (player == null)
        {
            GameObject p = GameObject.FindWithTag("Player");
            if (p != null)
                player = p.transform;
            else
                return; // no player found, stop here
        }

        // Follow the player
        transform.position = new Vector3(
            player.position.x,
            player.position.y,
            transform.position.z
        );
    }
}
