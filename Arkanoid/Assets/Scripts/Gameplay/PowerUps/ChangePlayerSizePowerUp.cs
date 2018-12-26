using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerSizePowerUp : MonoBehaviour
{

    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;

    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void ChangePlayerSize(float sizeScale, PowerUpController powerUpController)
    {
        if (sizeScale > maxSize)
            sizeScale = maxSize;
        if (sizeScale < minSize)
            sizeScale = minSize;
        powerUpController.PlayerController.ChangePlayerSize(sizeScale);
    }
}
