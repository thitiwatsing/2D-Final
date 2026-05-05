using UnityEngine;

public class PendulumSwing : MonoBehaviour
{
    [Header("Swing Settings")]
    public float swingAngle = 45f;   // องศาสูงสุดที่แกว่ง
    public float swingSpeed = 2f;    // ความเร็วในการแกว่ง

    private Quaternion startRotation;

    void Start()
    {
        startRotation = transform.rotation;
    }

    void Update()
    {
        float angle = swingAngle * Mathf.Sin(Time.time * swingSpeed);
        transform.rotation = startRotation * Quaternion.Euler(0f, 0f, angle);
    }
}