using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [Header("ลาก Image หัวใจจาก Canvas ใส่ List นี้")]
    public List<Image> hearts = new List<Image>();

    [Header("สีหัวใจ")]
    public Color colorFull  = Color.red;
    public Color colorEmpty = Color.white;

    void OnEnable()  => GameManager.OnHealthChanged += UpdateHearts;
    void OnDisable() => GameManager.OnHealthChanged -= UpdateHearts;

    void Start()
    {
        if (GameManager.Instance != null)
        {
            // Sync HP ให้ตรงกับจำนวนหัวใจใน List
            GameManager.Instance.maxHealth     = hearts.Count;
            GameManager.Instance.currentHealth = hearts.Count;
        }

        // แสดงหัวใจเต็มทุกดวงตอนเริ่ม
        UpdateHearts(hearts.Count, hearts.Count);
    }

    void UpdateHearts(int current, int max)
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (hearts[i] == null) continue;
            // i < current = ยังมีชีวิต → แดง
            // i >= current = HP หาย → ขาว
            hearts[i].color = (i < current) ? colorFull : colorEmpty;
        }
    }
}