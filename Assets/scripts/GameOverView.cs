using UnityEngine;
using TMPro;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI; 



    private void Awake()
    {
        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }

    private void OnEnable()
    {
        GameController.GameOver += Show;
    }

    private void OnDisable()
    {
        GameController.GameOver -= Show;
    }

    private void Show()
    {
        if (gameOverUI != null)
            gameOverUI.SetActive(true);
    }
}
