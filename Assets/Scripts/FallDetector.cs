using UnityEngine;

public class FallDetector : MonoBehaviour
{
    [Header("ระดับ Y ที่ถือว่าตกแผนที่")]
    public float fallLimit = -10f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        if (player.position.y < fallLimit)
        {
            if (GameManager.Instance != null)
                GameManager.Instance.GoToMenu();
            else
                UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
    }
}