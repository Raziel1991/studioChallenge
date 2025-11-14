using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float startTime = 30f;
    private float timeRemaining;

    [Header("UI References")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gemCountText;
    public Image gemIcon;

    private int gemCount = 0;

    void Start()
    {
        timeRemaining = startTime;
        UpdateGemUI();
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
        else
        {
            timeRemaining = 0;
            timerText.text = "00:00";
            GameOver();
        }
    }

    // Call this when a gem is collected
    public void CollectGem()
    {
        gemCount++;
        UpdateGemUI();

        // Example win condition: collect 5 gems
        if (gemCount >= 5)
        {
            WinGame();
        }
    }

    private void UpdateGemUI()
    {
        gemCountText.text = gemCount.ToString();
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

