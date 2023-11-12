using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 弾丸タグをチェック
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
            Destroy(collision.gameObject); // 弾丸を破壊
        }
    }

    void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 敵を破壊する処理
        Destroy(gameObject);

        // スコアを加算する
        ScoreManager.instance?.AddScore(10); // 10点を加算
    }
}
