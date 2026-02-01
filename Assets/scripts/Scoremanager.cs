using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int Score { get; private set; }
    public event Action<int> ScoreChanged;

    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Score = 0;
    }

    private void OnEnable()
    {
        PlayerController.Scored += HandleScored;
        GameController.GameOver += HandleGameOver;
    }

    private void OnDisable()
    {
        PlayerController.Scored -= HandleScored;
        GameController.GameOver -= HandleGameOver;
    }

    private void Start()
    {
        
        ScoreChanged?.Invoke(Score);
    }

    private void HandleScored()
    {
        if (GameController.IsGameOver) return;

        Score++;
        ScoreChanged?.Invoke(Score);
    }
    private void HandleGameOver()
{
    Debug.Log("Game Over!");
}

}
