using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{

    [Header("Power Ups")]
    [SerializeField] private GameObject[] powerUps;

    // Use this for initialization
    void Start()
    {
        GameController = FindObjectOfType<GameController>();
        BallsSpeedPowerUp = GetComponentInChildren<BallsSpeedPowerUp>();
        ChangePlayerSizePowerUp = GetComponentInChildren<ChangePlayerSizePowerUp>();
        MakeTripleBallsPowerUp = GetComponentInChildren<MakeTripleBallsPowerUp>();
        PlayerController = FindObjectOfType<PlayerController>();
    }

    public void SpawnPowerUp(Transform spawnPosition)
    {
        Instantiate(powerUps[Random.Range(0, powerUps.Length)], spawnPosition.position, Quaternion.identity);
    }

    public void ChangeBallsSpeed(bool canMultiply, float speedMultiply)
    {
        BallsSpeedPowerUp.ChangeSpeedOfBalls(canMultiply, speedMultiply, this);
    }

    public void ChangePlayerSize(float sizeScale)
    {
        ChangePlayerSizePowerUp.ChangePlayerSize(sizeScale, this);
    }

    public void MakeTripleBalls()
    {
        MakeTripleBallsPowerUp.MakeTriple(this);
    }

    public BallsSpeedPowerUp BallsSpeedPowerUp { get; set; }
    public ChangePlayerSizePowerUp ChangePlayerSizePowerUp { get; set; }
    public MakeTripleBallsPowerUp MakeTripleBallsPowerUp { get; set; }
    public GameController GameController { get; private set; }
    public PlayerController PlayerController { get; private set; }
}
