using UnityEngine;

public class PendulumSwing : MonoBehaviour
{
    public float swingAngle = 45f;
    public float swingSpeed = 2f;

    void Update()
    {
        float angle = swingAngle * Mathf.Sin(Time.time * swingSpeed);
        transform.localRotation = Quaternion.Euler(0f, 0f, angle);
    }
}