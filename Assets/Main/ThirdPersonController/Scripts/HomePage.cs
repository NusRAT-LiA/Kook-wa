using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePage : MonoBehaviour
{
    public void ResumeGame()
    {
        // Load the scene where the player left off
        SceneManager.LoadScene("MainScene 1");
    }

    public void NewGame()
    {
        // Reset any previous player data
        // For example, you can use PlayerPrefs.DeleteAll() to delete all saved player data
        PlayerPrefs.DeleteAll();
        
        // Load the initial game scene
        SceneManager.LoadScene("MainScene 1");
    }

    

    public void ExitGame()
    {
        // Quit the application
        Application.Quit();
    }

    public void exitFromScreen()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("HomePage");
            
        }
    }
}
