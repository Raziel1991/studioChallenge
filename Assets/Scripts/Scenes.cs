using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        // Make sure "GameOverScene" is added to Build Settings
        SceneManager.LoadScene("GameOverScene");
    }

    public void WinGame()
    {
        // Make sure "WinScene" is added to Build Settings
        SceneManager.LoadScene("WinScene");
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
