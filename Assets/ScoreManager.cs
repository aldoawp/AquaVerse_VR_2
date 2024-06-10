using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text scoreText;
    private int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        UpdateScoreText();
    }

    public void AddScore(int value)
    {
        score += value;
        PlayerPrefs.SetInt("score", score);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Collected: " + score.ToString() + "/10";
        }
    }
}
