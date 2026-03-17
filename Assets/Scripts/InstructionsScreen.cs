using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsScreen : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Orb Instructions");
    }
}
