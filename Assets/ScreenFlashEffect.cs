using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlashEffect : MonoBehaviour
{
    public Image flashImage; // フラッシュ用のイメージ
    public float fadeOutDuration = 0.5f; // フラッシュの持続時間

    public void Flash()
    {
        StartCoroutine(DoFlash());
    }

    private IEnumerator DoFlash()
    {
        // Alphaを最大にしてフラッシュさせる
        flashImage.color = new Color(flashImage.color.r, flashImage.color.g, flashImage.color.b, 0.85f);

        // フェードアウト: アルファを徐々に0に減少させる
        float elapsed = 0f;
        float currentAlpha = flashImage.color.a;

        while (elapsed < fadeOutDuration)
        {
            elapsed += Time.deltaTime;
            float newAlpha = Mathf.Lerp(currentAlpha, 0f, elapsed / fadeOutDuration);
            flashImage.color = new Color(flashImage.color.r, flashImage.color.g, flashImage.color.b, newAlpha);
            yield return null;
        }

        // 最終的にアルファを0に設定して完全に透明にする
        flashImage.color = new Color(flashImage.color.r, flashImage.color.g, flashImage.color.b, 0f);
    }
}
