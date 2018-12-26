using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text timeText, scoreText, livesText;
    [SerializeField] private GameObject gameOverPanel;

    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        SetTimeScale = 1f;
        gameController = FindObjectOfType<GameController>();
    }

    public void GameOver()
    {
        SetTimeScale = 0.000000000001f;
        gameOverPanel.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }

    public IEnumerator TimeCount()
    {
        timeText.text = "3";
        yield return new WaitForSeconds(1f);
        timeText.text = "2";
        yield return new WaitForSeconds(1f);
        timeText.text = "1";
        yield return new WaitForSeconds(1f);
        gameController.isGameStart = true;
        timeText.text = "Go!";
        yield return new WaitForSeconds(1f);
        timeText.gameObject.SetActive(false);
    }

    private float SetTimeScale { set { Time.timeScale = value; } }

}
