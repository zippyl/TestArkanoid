using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [Header("Levels")]
    [SerializeField] private GameObject[] levelObjects;

    private GameController gameController;
    private UIController uiController;

    private int lastSavedLevel;
    private int childCount = 0;

    // Use this for initialization
    void Start()
    {
        CanChangeLevel = false;
        gameController = FindObjectOfType<GameController>();
        uiController = FindObjectOfType<UIController>();
        lastSavedLevel = PlayerPrefs.GetInt("Level", 0);
        Instantiate(levelObjects[lastSavedLevel]);
    }

    public void LoadLevel()
    {
        lastSavedLevel++;
        if (lastSavedLevel >= 3)
        {
            
            PlayerPrefs.SetInt("Level", 0);
            CanChangeLevel = false;
            return;
        }
        Instantiate(levelObjects[lastSavedLevel]);
        PlayerPrefs.SetInt("Level", lastSavedLevel);
        CanChangeLevel = false;
    }

    public bool CanChangeLevel { get; set; }
}
