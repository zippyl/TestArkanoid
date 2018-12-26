using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{

    [SerializeField] private Sprite brokenBlock;
    [SerializeField] private bool isSolidBlock = false;
    [SerializeField] private int blockHitValue = 2;
    [SerializeField] private int scoreValue = 10;

    private SpriteRenderer spriteRenderer;
    private GameController gameController;
    private PowerUpController powerUpController;

    // Use this for initialization
    void Start()
    {
        powerUpController = FindObjectOfType<PowerUpController>();
        gameController = FindObjectOfType<GameController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BlockHit()
    {
        var randNumber = Random.Range(1, 101);
        Debug.Log(randNumber);
        if(isSolidBlock)
        {
            blockHitValue--;
            if(blockHitValue == 0)
            {
                if(randNumber > 35 && randNumber <= 65)
                {
                    powerUpController.SpawnPowerUp(gameObject.transform);
                }
                gameController.AddScore(scoreValue);
                Destroy(gameObject);
            }
            spriteRenderer.sprite = brokenBlock;
            return;
        }
        if (randNumber > 35 && randNumber <= 65)
        {
            powerUpController.SpawnPowerUp(gameObject.transform);
        }
        gameController.AddScore(scoreValue);
        Destroy(gameObject);
    }

    //падают поверапы
}
