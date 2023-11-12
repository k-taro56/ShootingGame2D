using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    void Update()
    {
        // 画面外かどうかを判定するためのカメラのビューポート座標を取得
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        
        // 画面外に出たら弾丸を破棄
        if (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
        {
            Destroy(gameObject);
        }
    }
}
