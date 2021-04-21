using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{


    public Text scoreText;
    public int score;
    const int maxScore = 6000;
    public bool playerDead;

    // Use this for initialization
    void Start()
    {
        score = 0;
        playerDead = false;
        UpdateScore();

        GameObject.Find("Canvas_win").GetComponent<Canvas>().enabled = false;
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
        }

        if (playerDead == false)
        {
            score++;

            if(score >= maxScore)
            {
                playerDead = true;
                GameObject.Find("Canvas_win").GetComponent<Canvas>().enabled = true;

                Time.timeScale = 0;
            }
        }

        UpdateScore();
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
