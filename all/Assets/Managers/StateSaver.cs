using UnityEngine;
using UnityEngine.SceneManagement;

public static class StateSaver
{
    public static string lastScene;
    
    public static void SaveCurrentScene()
    {
        lastScene = SceneManager.GetActiveScene().name;
    }
    
    
    public static void ReturnToLastScene()
    {
        if (!string.IsNullOrEmpty(lastScene))
        {
            SceneManager.LoadScene(lastScene);
        }
        else
        {
            Debug.LogWarning("No last scene saved!");
            SceneManager.LoadScene("MainMenu");
        }
    }
    
}