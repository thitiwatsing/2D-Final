using UnityEngine;

public class PendulumKick : MonoBehaviour
{
    public float kickForce = 3f;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(kickForce, 0), ForceMode2D.Impulse);
    }
}