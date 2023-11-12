using UnityEngine;
using TMPro; // TextMeshProを使用する場合

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI healthText; // TextMeshProの場合

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 敵と衝突したか確認
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(10); // ダメージ量を設定
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        healthText.text = "HP: " + currentHealth;
    }

    void Die()
    {
        // プレイヤーの死亡処理
        Debug.Log("Player Died!");
    }
}
