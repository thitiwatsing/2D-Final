using UnityEngine;

/// <summary>
/// ติดกับ Object ที่เป็นเป้าหมาย/ปลายทาง เช่น ประตู, ธง, สัญลักษณ์จบด่าน
/// ต้องมี Collider 2D และติ๊ก "Is Trigger"
/// </summary>
public class GoalTrigger : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Tag ของ Object ที่ชนแล้วจะเปลี่ยน Scene (ปกติคือ Player)")]
    public string targetTag = "Player";

    [Tooltip("หน่วงเวลาก่อนเปลี่ยน Scene (วินาที)")]
    public float delay = 0.3f;

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag(targetTag))
        {
            triggered = true;
            Debug.Log("[GoalTrigger] ผู้เล่นถึงเป้าหมาย! กำลังไป End Scene...");
            Invoke(nameof(LoadEndScene), delay);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!triggered && other.gameObject.CompareTag(targetTag))
        {
            triggered = true;
            Invoke(nameof(LoadEndScene), delay);
        }
    }

    void LoadEndScene()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.GoToEndScene();
        else
            UnityEngine.SceneManagement.SceneManager.LoadScene("End");
    }
}