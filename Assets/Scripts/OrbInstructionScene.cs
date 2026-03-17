using UnityEngine;
using UnityEngine.SceneManagement;

public class OrbInstructionsScreen : MonoBehaviour
{
    public void StartGame()
    {
        BossDefeatTracker.timesDefeated = 0;
        SceneManager.LoadScene("Gameplay");
    }
}
