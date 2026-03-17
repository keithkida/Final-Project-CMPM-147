using UnityEngine;

public class BreakableStone : MonoBehaviour
{
    public GameObject orbBehindStone;

    public void Break() 
    {
        if (orbBehindStone != null)
            orbBehindStone.SetActive(true);

        Destroy(gameObject);
    }
}
