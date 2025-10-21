using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;
    public Button quitButton;
    public AudioClip menuTheme;
    private int menuMusicID = -1;
    
    
    void Start()
    {
        menuMusicID = AudioManager.Instance.PlayLoopingSound(menuTheme, 0.3f);
        startButton.onClick.AddListener(OnStartClicked);
        quitButton.onClick.AddListener(OnQuitClicked);
        optionsButton.onClick.AddListener(OnOptionsClicked);
    }
    
    void OnStartClicked()
    {
        AudioManager.Instance.StopLoopingSound(menuMusicID);
        AudioManager.Instance.PlayButtonClick();
        
        // Load lore scene
        SceneLoader.Instance.LoadLoreScene();
    }

    void OnQuitClicked()
    {
        AudioManager.Instance.StopLoopingSound(menuMusicID);
        AudioManager.Instance.PlayButtonClick();
        SceneLoader.Instance.QuitGame();
    }

    void OnOptionsClicked()
    {
        AudioManager.Instance.StopLoopingSound(menuMusicID);
        AudioManager.Instance.PlayButtonClick();
        StateSaver.SaveCurrentScene();
        SceneLoader.Instance.LoadOptionsScene();         //go to options scene
    }
    
}