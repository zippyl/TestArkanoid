using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsSpeedPowerUp : MonoBehaviour
{
    public void ChangeSpeedOfBalls(bool canMultiplay, float speedMultiply, PowerUpController powerUpController)
    {
        foreach (var item in powerUpController.GameController.GetBalls())
        {
            if (canMultiplay)
                item.GetComponent<BallMovement>().ChangeSpeed(true, 2);
            else
                item.GetComponent<BallMovement>().ChangeSpeed(false, 2);
        }
    }
}
