using UnityEngine;
using TMPro;
using UnityEngine.UI; // TextMeshProを使用する場合

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI healthText; // TextMeshProの場合
    public GameObject gameOver; 
    public EnemySpawner spawner;

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
        Destroy(gameObject);
        gameOver.gameObject.SetActive(true);

        // スポーン処理を停止
        spawner.StopSpawning();

        // ゲームオーバー処理
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
    }
}
