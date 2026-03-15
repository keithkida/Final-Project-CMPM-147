using UnityEngine;
using TMPro;

public class EndScreenUI : MonoBehaviour
{
    public TextMeshProUGUI bossDefeatText;

    void Start()
    {
        bossDefeatText.text = "Nice play\nNext time is for the win\nLets try again\nBoss defeated:\n " + BossDefeatTracker.timesDefeated;
    }
}
