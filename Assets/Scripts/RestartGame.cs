using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void Restart()
    {
        PlayerPersistence.ResetPlayer();
        BossDefeatTracker.timesDefeated = 0;
        AmmoUI.Instance.ResetAmmo();
        PickaxeUI.Instance.Hide();  
        SceneManager.LoadScene("Title Screen");
    }
}
