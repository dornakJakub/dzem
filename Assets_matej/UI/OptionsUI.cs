using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public Button backButton;
    public Button quitButton;
    public Button resetButton;
    public AudioClip optionsTheme;
    private int optionsMusicID = -1;

    [Header("Volume Sliders")]
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        optionsMusicID = AudioManager.Instance.PlayLoopingSound(optionsTheme, 0.3f);
        backButton.onClick.AddListener(OnBackClicked);
        quitButton.onClick.AddListener(OnQuitClicked);

        masterVolumeSlider.value = AudioManager.Instance.MasterVolume;
        musicVolumeSlider.value = AudioManager.Instance.MainThemeVolume;

        // Add listeners for real-time updates
        masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
        musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
    }

    void OnLeaveClicked()
    {
        AudioManager.Instance.StopLoopingSound(optionsMusicID);
        AudioManager.Instance.ResumeMainTheme();
        AudioManager.Instance.PlayButtonClick();
        SceneLoader.Instance.LoadCounterScene();
    }

    void OnQuitClicked()
    {
        AudioManager.Instance.StopLoopingSound(optionsMusicID);
        AudioManager.Instance.PlayButtonClick();
        SceneLoader.Instance.QuitGame();
    }
    void OnBackClicked()
    {
        AudioManager.Instance.StopLoopingSound(optionsMusicID);
        AudioManager.Instance.PlayButtonClick();
        StateSaver.ReturnToLastScene();
    }

    private void OnMasterVolumeChanged(float volume)
    {
        AudioManager.Instance.SetMasterVolume(volume);
    }

    private void OnMusicVolumeChanged(float volume)
    {
        AudioManager.Instance.SetMainThemeVolume(volume);
    }


}
