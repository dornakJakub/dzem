using card_logic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CounterUI : MonoBehaviour
{
    public Button serveButton;
    public Button optionsButton;
    public Button cookBookButton;

    
    void Start()
    {
        if (!AudioManager.Instance.IsMainThemePaused() && (string.Compare(StateSaver.lastScene,"Kitchen") != 0))
        {
            AudioManager.Instance.PlayMainTheme();
            Debug.Log($"last scene {StateSaver.lastScene}");
        }
        else if(AudioManager.Instance.IsMainThemePaused())
        {
            AudioManager.Instance.ResumeMainTheme();
        }
        serveButton.onClick.AddListener(OnServeClicked);
        optionsButton.onClick.AddListener(OnOptionsClicked);
        cookBookButton.onClick.AddListener(OnCookBookClicked);
    }
    
    void OnServeClicked()
    {
        AudioManager.Instance.PlayServeSound();
        Serve.Instance.OnServe();
        // Load lore scene
        //SceneLoader.Instance.LoadLoreScene();
    }

    void OnOptionsClicked()
    {
        AudioManager.Instance.PauseMainTheme();
        AudioManager.Instance.PlayButtonClick();
        StateSaver.SaveCurrentScene();
        SceneLoader.Instance.LoadOptionsScene();
    }
    void OnCookBookClicked()
    {
        AudioManager.Instance.PauseMainTheme();
        AudioManager.Instance.PlayButtonClick();
        StateSaver.SaveCurrentScene();
        SceneLoader.Instance.LoadCookBookScene();
    }
    /*
    void Update()
    {
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            OnLeftClicked();
        }
    }

    void OnLeftClicked()
    {
        AudioManager.Instance.PlayButtonClick();
        SceneLoader.Instance.LoadKitchenScene();
    }
    */
}