using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void LoadLoreScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadCounterScene()
    {
        SceneManager.LoadScene(2);
    }
    
    public void LoadKitchenScene()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadCookBookScene()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene(5);
    }
    
    
    public void QuitGame()
    {
        Application.Quit();
    }
}