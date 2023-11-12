using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemiesParent;
    public float spawnRate = 2.0f;
    public float spawnMargin = 0.6f; // 画面の端からのマージン
    public int maxEnemies = 15; // 一度に存在できる敵の最大数

    private float nextSpawnTime;
    private int currentEnemyCount; // 現在の敵の数

    void Update()
    {
        if (enemiesParent is null)
        {
            return;
        }
        
        currentEnemyCount = enemiesParent.transform.childCount;

        if (Time.time >= nextSpawnTime && currentEnemyCount < maxEnemies)
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
        float spawnPosY = Random.Range(min.y + spawnMargin * 6, max.y - spawnMargin);
        Vector2 spawnPosition = new(spawnPosX, spawnPosY);

        // 敵をインスタンス化し、設定した位置に配置する
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemy.transform.parent = enemiesParent.transform;

    }
}
