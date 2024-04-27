using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        // Invoke the LoadScene method after 3 seconds
        Invoke("LoadScene", 3f);
    }

    void LoadScene()
    {
        // Load the homepage scene
        SceneManager.LoadScene("MainScene 2");
    }
}
