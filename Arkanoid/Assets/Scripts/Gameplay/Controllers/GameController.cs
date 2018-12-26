using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [Header("Blocks")]
    [SerializeField] private GameObject blueBlock;
    [SerializeField] private GameObject redBlock;
    [SerializeField] private GameObject greenBlock;

    [Header("Help Ball")]
    [SerializeField] private GameObject helpBall;
    [SerializeField] private GameObject[] balls;

    private UIController uiController;
    private BallMovement ball;

    private int mainScore;
    private float savedScore;

    // Use this for initialization
    void Start()
    {
        savedScore = PlayerPrefs.GetFloat("Score", 0);
        uiController = FindObjectOfType<UIController>();
        ball = FindObjectOfType<BallMovement>();
        Lives = 3;
        isGameStart = false;
        StartCoroutine(uiController.TimeCount());
    }

    // Update is called once per frame
    void Update()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
        var helpBalls = GameObject.FindGameObjectsWithTag("HelpBall");
        balls.Concat(helpBalls);
    }

    public void GameOver()
    {
        //Save state of game
        uiController.GameOver();
    }

    public void AddScore(int scoreValue)
    {
        mainScore += scoreValue;
        uiController.UpdateScore(mainScore);
    }

    public void DecLives()
    {
        Lives--;
        uiController.UpdateLives(Lives);
        ball.ResetPosition(.4f);
        if (Lives == 0)
        {
            if (mainScore > savedScore)
            {
                PlayerPrefs.SetFloat("Score", mainScore);
            }
            GameOver();
        }
    }

    public GameObject[] GetBalls()
    {
        return balls;
    }

    public bool isGameStart { get; set; }
    public int Lives { get; set; }
    public GameObject HelpBall { get { return helpBall; } }
}
