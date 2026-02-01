using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool IsGameOver { get; private set; }
    public static event Action GameOver;

    private void Awake()
    {
        IsGameOver = false;
        Time.timeScale = 1f;
    }

    public static void TriggerGameOver()
    {
        if (IsGameOver) return;

        IsGameOver = true;
        GameOver?.Invoke();

        Time.timeScale = 0f;
    }
}
