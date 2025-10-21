using card_logic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class KitchenUI : MonoBehaviour
{
    public Button serveButton;
    public Button optionsButton;
    public Button cookBookButton;


    
    void Start()
    {
        if (AudioManager.Instance.IsMainThemePaused())
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

    void Update()
    {
        // Check for Escape key press
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            OnRightClicked();
        }
    }

    void OnRightClicked()
    {
        AudioManager.Instance.PlayButtonClick();
        StateSaver.SaveCurrentScene();
        SceneLoader.Instance.LoadCounterScene();
    }

}