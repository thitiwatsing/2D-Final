using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ติดกับ GameObject บน Canvas ใน Scene Menu
/// ลาก Button START ใส่ช่อง startButton
/// </summary>
public class MenuManager : MonoBehaviour
{
    [Header("ลาก Button START เข้ามา")]
    public Button startButton;

    void Start()
    {
        // ถ้าลาก Button ไว้ใน Inspector
        if (startButton != null)
            startButton.onClick.AddListener(OnStartClicked);
    }

    // เรียกจาก Button OnClick() ก็ได้ หรือผ่าน Listener ก็ได้
    public void OnStartClicked()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartGame();
        }
        else
        {
            // กรณีไม่มี GameManager (test จาก Scene Menu โดยตรง)
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }
    }
}