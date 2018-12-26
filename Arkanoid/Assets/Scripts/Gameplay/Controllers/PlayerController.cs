using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PowerUpController powerUpController;

    // Use this for initialization
    void Start()
    {
        powerUpController = FindObjectOfType<PowerUpController>();
    }

    public void ChangePlayerSize(float value)
    {
        transform.localScale = new Vector3(value, transform.localScale.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PowerUpSize")
        {
            Debug.Log("Size up");
            powerUpController.ChangePlayerSize(1.5f);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "PowerUpSizeLess")
        {
            Debug.Log("Size less");
            powerUpController.ChangePlayerSize(0.4f);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "PowerUpSpeed")
        {
            Debug.Log("Speed up");
            powerUpController.ChangeBallsSpeed(true, 2);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "PowerUpSpeedLess")
        {
            Debug.Log("Speed less");
            powerUpController.ChangeBallsSpeed(false, 2);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "PowerUpTriple")
        {
            Debug.Log("Tripppppple kill");
            powerUpController.MakeTripleBalls();
            Destroy(collision.gameObject);
        }
    }
}
