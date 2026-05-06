using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button retryButton;
    public Button menuButton;

    [Header("Result UI")]
    public TMP_Text timeText;
    public TMP_Text scoreText;

    void Start()
    {
        if (retryButton != null)
            retryButton.onClick.AddListener(OnRetryClicked);

        if (menuButton != null)
            menuButton.onClick.AddListener(OnMenuClicked);

        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.StopTimer();
            int minutes = (int)(ScoreManager.Instance.playTime / 60);
            int seconds = (int)(ScoreManager.Instance.playTime % 60);

            if (timeText != null)
                timeText.text = $"Time : {minutes:00}:{seconds:00}";

            if (scoreText != null)
                scoreText.text = $"Score : {ScoreManager.Instance.score}";
        }
    }

    public void OnRetryClicked()
    {
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.ResetAll();

        if (GameManager.Instance != null)
            GameManager.Instance.RestartGame();
        else
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void OnMenuClicked()
    {
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.ResetAll();

        if (GameManager.Instance != null)
            GameManager.Instance.GoToMenu();
        else
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}