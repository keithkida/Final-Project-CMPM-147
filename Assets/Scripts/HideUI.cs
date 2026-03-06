using UnityEngine;

public class HideUI : MonoBehaviour
{
    public float hideAfterSeconds = 5f;
    
    void OnEnable() {
        CancelInvoke();
        Invoke(nameof(Hide), hideAfterSeconds);
    }

    void Hide() {
        gameObject.SetActive(false);
    }
}
