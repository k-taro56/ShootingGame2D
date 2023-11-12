using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2.0f;
    private float nextSpawnTime;
    public float spawnMargin = 0.1f; // 画面の端からのマージン

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    void SpawnEnemy()
    {
        // カメラのビューポートから画面の端の座標を取得する
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // マージンを考慮したスポーン位置を画面内にランダムに設定する
        float spawnPosX = Random.Range(min.x + spawnMargin, max.x - spawnMargin);
        float spawnPosY = Random.Range(min.y + spawnMargin, max.y - spawnMargin);
        Vector2 spawnPosition = new Vector2(spawnPosX, spawnPosY);

        // 敵をインスタンス化し、設定した位置に配置する
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
