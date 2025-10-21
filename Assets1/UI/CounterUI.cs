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
        if (!AudioManager.Instance.IsMainThemePaused())
        {
            AudioManager.Instance.PlayMainTheme();
        }
        else
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
        
        // Load lore scene
        //SceneLoader.Instance.LoadLoreScene();
    }

    void OnOptionsClicked()
    {
        AudioManager.Instance.PauseMainTheme();
        AudioManager.Instance.PlayButtonClick();
        SceneLoader.Instance.LoadOptionsScene();
    }
    void OnCookBookClicked()
    {
        AudioManager.Instance.PauseMainTheme();
        AudioManager.Instance.PlayButtonClick();
        SceneLoader.Instance.LoadCookBookScene();
    }

    void Update()
    {
        // Check for Escape key press
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

}