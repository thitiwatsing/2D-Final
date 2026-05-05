using UnityEngine;
using UnityEngine.UI;
using TMPro; // ใช้ TextMeshPro (ถ้าใช้ Text ธรรมดาให้เปลี่ยน TMP_Text เป็น Text)

/// <summary>
/// ติดกับ GameObject บน Canvas ใน Scene End
/// </summary>
public class EndManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button retryButton;   // เล่นใหม่ -> Main
    public Button menuButton;    // กลับ -> Menu

    [Header("Optional - แสดงข้อความ")]
    public TMP_Text messageText; // ถ้าไม่ใช้ TMP ให้ลบบรรทัดนี้และบรรทัด Start() ที่เกี่ยวข้อง

    void Start()
    {
        if (retryButton != null)
            retryButton.onClick.AddListener(OnRetryClicked);

        if (menuButton != null)
            menuButton.onClick.AddListener(OnMenuClicked);

        // แสดงข้อความตาม HP ที่เหลือ (ถ้ามี Text)
        if (messageText != null && GameManager.Instance != null)
        {
            if (GameManager.Instance.currentHealth <= 0)
                messageText.text = "Game Over!";
            else
                messageText.text = "You Win!";
        }
    }

    public void OnRetryClicked()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.RestartGame();
        else
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void OnMenuClicked()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.GoToMenu();
        else
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}