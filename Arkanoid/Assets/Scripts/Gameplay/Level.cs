using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    private LevelController levelController;
    private BallMovement ball;

    // Use this for initialization
    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        ball = FindObjectOfType<BallMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.childCount);
        if (transform.childCount <= 0)
        {
            levelController.LoadLevel();
            ball.ResetPosition(2f);
            Destroy(gameObject);
        }
    }
}
