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
        serveButton.onClick.AddListener(OnServeClicked);
        optionsButton.onClick.AddListener(OnOptionsClicked);
        cookBookButton.onClick.AddListener(OnCookBookClicked);
    }
    
    void OnServeClicked()
    {
        AudioManager.Instance.PlayServeSound();
        
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
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            OnRightClicked();
        }
    }

    void OnRightClicked()
    {
        AudioManager.Instance.PlayButtonClick();
        SceneLoader.Instance.LoadCounterScene();
    }

}