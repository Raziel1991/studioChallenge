using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Timer : MonoBehaviour
{

    [SerializeField]
    public float startTime = 30f;     // Set countdown start time in seconds
    private float timeRemaining;
    public TextMeshProUGUI timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeRemaining = startTime;
    }

    // Update is called once per frame
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


    //play when game is finished
    public void GameOver()
    {
        SceneManager.LoadSceneAsync(1);
    }
}