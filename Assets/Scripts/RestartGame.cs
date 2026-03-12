using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void Restart()
    {
        PlayerPersistence.ResetPlayer();
        SceneManager.LoadScene("Title Screen");
    }
}
