using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // シングルトンパターンを使用
    public TextMeshProUGUI scoreText; // スコアを表示するためのテキスト
    private int score = 0; // 現在のスコア

    void Awake()
    {
        // シングルトンパターンを確保
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
