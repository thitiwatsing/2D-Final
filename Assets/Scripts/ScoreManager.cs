using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;
    public float playTime = 0f;
    private bool timing = true;

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

    void Update()
    {
        if (timing)
            playTime += Time.deltaTime;
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log($"Score: {score}");
    }

    public void StopTimer() => timing = false;

    public void ResetAll()
    {
        score = 0;
        playTime = 0f;
        timing = true;
    }
}