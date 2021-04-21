using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{


    public Text scoreText;
    private int score;

    public bool playerDead;

    // Use this for initialization
    void Start()
    {
        score = 0;
        playerDead = false;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {

        if (score < 0)
        {
            score = 0;
            playerDead = true;


            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
            UpdateScore();
        }

        if (playerDead == false)
        {
            score++;

            UpdateScore();
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
