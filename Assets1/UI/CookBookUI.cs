using UnityEngine;
using UnityEngine.UI;
public class CookBookUI : MonoBehaviour
{
    public Button leaveButton;
    public AudioClip cookbookTheme;
    private int cookbookMusicID = -1;
    void Start()
    {
        cookbookMusicID = AudioManager.Instance.PlayLoopingSound(cookbookTheme, 0.3f);
        leaveButton.onClick.AddListener(OnLeaveClicked);

    }
    
    void OnLeaveClicked()
    {   
        AudioManager.Instance.StopLoopingSound(cookbookMusicID);
        AudioManager.Instance.PlayButtonClick();
        SceneLoader.Instance.LoadCounterScene();
    }

}