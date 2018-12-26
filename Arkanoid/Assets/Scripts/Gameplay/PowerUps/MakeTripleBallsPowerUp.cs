using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTripleBallsPowerUp : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MakeTriple(PowerUpController powerUpController)
    {
        var curPos = powerUpController.Ball.transform.position;
        var curRot = powerUpController.Ball.transform.eulerAngles;
        for (int i = 0; i < 3; i++)
        {
            if (i == 0)
                Instantiate(powerUpController.GameController.HelpBall, curPos + powerUpController.Ball.transform.up, Quaternion.Euler(curPos.x, curPos.y, curPos.z));
            if (i == 1)
                Instantiate(powerUpController.GameController.HelpBall, curPos + powerUpController.Ball.transform.up, Quaternion.Euler(curPos.x, curPos.y, curPos.z + 25f));
            if (i == 2)
                Instantiate(powerUpController.GameController.HelpBall, curPos + powerUpController.Ball.transform.up, Quaternion.Euler(curPos.x, curPos.y, curPos.z - 25f));

        }
    }
}
