using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private GameController gameController;
    private Rigidbody2D rigidbody2d;

    // Use this for initialization
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.isGameStart)
        {
            if (Input.GetMouseButton(0))
            {
                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(mousePos.x, transform.position.y);
            }
        }
    }
}
