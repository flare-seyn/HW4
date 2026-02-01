using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.ScoreChanged += UpdateScoreText;
        }
    }

    private void OnDisable()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.ScoreChanged -= UpdateScoreText;
        }
    }

    private void Start()
    {
        if (scoreText != null && ScoreManager.Instance != null)
        {
            scoreText.text = ScoreManager.Instance.Score.ToString();
        }
    }

    private void UpdateScoreText(int score)
    {
        if (scoreText == null) return;
        scoreText.text = score.ToString();
    }
}
