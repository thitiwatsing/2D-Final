using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Transform cam;
    private Vector3 lastCamPos;

    [Range(0f, 1f)]
    public float parallaxSpeed = 0.2f; // 0 = ติดกับกล้อง, 1 = อยู่กับที่

    void Start()
    {
        cam = Camera.main.transform;
        lastCamPos = cam.position;
    }

    void LateUpdate()
    {
        Vector3 delta = cam.position - lastCamPos;
        transform.position += new Vector3(delta.x * parallaxSpeed, 0, 0);
        lastCamPos = cam.position;
    }
}