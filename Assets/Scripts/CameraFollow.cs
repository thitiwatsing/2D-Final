using UnityEngine;

/// <summary>
/// ติดกับ Main Camera ใน Scene Main
/// ลาก Player GameObject ใส่ช่อง target
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform target; // ลาก Player เข้ามา

    [Header("Follow Settings")]
    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(0f, 1f, -10f);

    [Header("Boundary - จำกัดพื้นที่กล้อง (ไม่บังคับ)")]
    public bool useBoundary = false;
    public float minX = -50f, maxX = 50f;
    public float minY = -10f, maxY = 20f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desired = target.position + offset;

        if (useBoundary)
        {
            desired.x = Mathf.Clamp(desired.x, minX, maxX);
            desired.y = Mathf.Clamp(desired.y, minY, maxY);
        }

        // Z ต้องคงเดิมเสมอ (-10 สำหรับกล้อง 2D)
        desired.z = offset.z;

        transform.position = Vector3.Lerp(transform.position, desired, smoothSpeed * Time.deltaTime);
    }
}