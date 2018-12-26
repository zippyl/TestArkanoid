using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [Header("Blocks")]
    [SerializeField] private GameObject blueBlock;
    [SerializeField] private GameObject redBlock;
    [SerializeField] private GameObject greenBlock;

    private UIController uiController;

    private int mainScore;
    private GameObject[] balls;

    // Use this for initialization
    void Start()
    {
        Lives = 3;
        uiController = FindObjectOfType<UIController>();
        for (float i = -8.05f; i <= 8.05f; i += 1.15f)
        {
            Instantiate(redBlock, new Vector3(i, 4f), Quaternion.identity);
            Instantiate(blueBlock, new Vector3(i, 3.3f), Quaternion.identity);
            Instantiate(greenBlock, new Vector3(i, 2.6f), Quaternion.identity);
        }
        isGameStart = false;
        StartCoroutine(uiController.TimeCount());
    }

    // Update is called once per frame
    void Update()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
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

        Debug.LogError("Reset ball position!");

        if (Lives == 0)
        {
            GameOver();
        }
    }

    public GameObject[] GetBalls()
    {
        return balls;
    }

    public bool isGameStart { get; set; }
    public int Lives { get; set; }
}
