using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    [SerializeField] private Text highscoreText;

    // Use this for initialization
    void Start()
    {
        highscoreText.text = "Your best score: " + PlayerPrefs.GetFloat("Score", 0);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
