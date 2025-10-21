using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class LoreUI : MonoBehaviour
{
    public AudioClip loreTheme;
    private int loreMusicID = -1;
    void Start()
    {
        loreMusicID = AudioManager.Instance.PlayLoopingSound(loreTheme, 0.3f);
    }
    void Update()
    {
        // Check for Escape key press
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            OnSkipClicked();
        }
    }
    
    void OnSkipClicked()
    {
        if (loreMusicID != -1)
        {
            AudioManager.Instance.StopLoopingSound(loreMusicID);
            loreMusicID = -1;
        }
        AudioManager.Instance.PlayButtonClick();
        SceneLoader.Instance.LoadCounterScene();
    }

}
