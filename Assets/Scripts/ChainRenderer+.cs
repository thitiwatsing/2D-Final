using UnityEngine;

public class ChainRenderer : MonoBehaviour
{
    public Transform ball;
    public int segments = 8;
    public float width = 0.1f;

    private LineRenderer lr;

    void Start()
    {
        lr = gameObject.AddComponent<LineRenderer>();
        lr.positionCount = segments;
        lr.startWidth = width;
        lr.endWidth = width;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = Color.gray;
        lr.endColor = Color.gray;
    }

    void Update()
    {
        if (ball == null) return;

        for (int i = 0; i < segments; i++)
        {
            float t = i / (float)(segments - 1);
            Vector3 point = Vector3.Lerp(transform.position, ball.position, t);
            lr.SetPosition(i, point);
        }
    }
}