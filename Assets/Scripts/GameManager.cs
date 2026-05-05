using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // HealthUI Subscribe Event นี้เพื่ออัพเดตสีหัวใจ
    public static System.Action<int, int> OnHealthChanged;

    public int maxHealth     = 5;
    public int currentHealth = 5;

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

    public void TakeDamage(int amount)
    {
        if (currentHealth <= 0) return;

        currentHealth -= amount;
        currentHealth  = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"[GameManager] HP: {currentHealth}/{maxHealth}");

        // ยิง Event ให้ HealthUI อัพเดตสีหัวใจทันที
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
            Invoke(nameof(GoToMenu), 0.5f);
    }

    public void StartGame()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        SceneManager.LoadScene("Main");
    }

    public void GoToEndScene() => SceneManager.LoadScene("End");
    public void GoToMenu()     => SceneManager.LoadScene("Menu");
    public void RestartGame()
    {
        currentHealth = maxHealth;
        SceneManager.LoadScene("Main");
    }
}