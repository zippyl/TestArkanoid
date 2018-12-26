using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    [Header("Random angle")]
    [SerializeField] private float minRandomAngle;
    [SerializeField] private float maxRandomAngle;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float increaseSpeedValue;
    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        transform.eulerAngles = new Vector3(0f, 0f, Random.Range(minRandomAngle, maxRandomAngle));
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.isGameStart)
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathWall")
        {
            Debug.Log("Bye ball");
            gameController.DecLives();
        }
        if (collision.gameObject.tag == "Corner")
        {
            Debug.Log("Hi, Corner");
            MakeBounce(collision, 0.7f);
        }
        if (collision.gameObject.tag == "Block")
        {
            Debug.Log("Hi, Block");
            moveSpeed += increaseSpeedValue;
            collision.gameObject.GetComponent<BlockController>().BlockHit();
        }
        MakeBounce(collision);
    }

    private void MakeBounce(Collision2D collision, float normalMultiply = 1f)
    {
        var curDir = transform.TransformDirection(Vector3.up);
        var newPos = CalculateAngle(curDir, collision.contacts[0].normal * normalMultiply);
        var newRot = Quaternion.FromToRotation(Vector3.up, newPos);
        transform.rotation = newRot;
    }

    private Vector3 CalculateAngle(Vector2 vector, Vector2 normal)
    {
        return vector - (2 * normal * Vector2.Dot(vector, normal));
    }

    public void ChangeSpeed(bool canMultiply, float speedMultiply)
    {
        if (canMultiply)
            moveSpeed *= speedMultiply;
        else
            moveSpeed /= speedMultiply;
    }
}
