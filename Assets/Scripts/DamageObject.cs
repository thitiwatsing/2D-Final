using UnityEngine;

public class DamageObject : MonoBehaviour
{
    [Header("Damage Settings")]
    [Tooltip("ดาเมจที่หัก HP (ปรับได้แต่ละ Object)")]
    public int   damageAmount     = 1;

    [Tooltip("ป้องกันดาเมจถี่เกิน (วินาที)")]
    public float damageCooldown   = 1f;

    [Tooltip("ติ๊กถ้าให้ดาเมจตลอดเวลาที่อยู่ใน Trigger")]
    public bool  continuousDamage = false;

    private float lastDamageTime  = -999f;

    // ===== Trigger (ติ๊ก Is Trigger บน Collider) =====
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"[DamageObject] Trigger กับ Player!");
            TryApplyDamage();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (continuousDamage && other.CompareTag("Player"))
            TryApplyDamage();
    }

    // ===== Collision (ไม่ติ๊ก Is Trigger) =====
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log($"[DamageObject] Collision กับ Player!");
            TryApplyDamage();
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (continuousDamage && other.gameObject.CompareTag("Player"))
            TryApplyDamage();
    }

    // ===== Core =====
    void TryApplyDamage()
    {
        // เช็ค Cooldown
        if (Time.time - lastDamageTime < damageCooldown) return;
        lastDamageTime = Time.time;

        // เรียก GameManager → GameManager ยิง Event → HealthUI อัพเดตสีหัวใจ
        if (GameManager.Instance != null)
            GameManager.Instance.TakeDamage(damageAmount);
        else
            Debug.LogError("[DamageObject] ไม่พบ GameManager!");
    }
}