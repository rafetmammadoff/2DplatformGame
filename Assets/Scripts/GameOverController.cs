using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverController : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] TextMeshProUGUI currentScore;
    // private ScoreCounter scoreCounter;
    private PlayerController playerController;
    private void Awake()
    {
        // scoreCounter = GetComponent<ScoreCounter>();
        playerController = FindObjectOfType<PlayerController>();
    }

    public void GameOverShowPanel() {
        Time.timeScale = 0f;
        gameOverCanvas.enabled = true;
        // currentScore.text = scoreCounter.GetScore().ToString();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
