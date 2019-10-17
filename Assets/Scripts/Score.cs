using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score = 0;
    public int difficultyLevel = 1;
    public int maxDifficultyLevel = 10;
    public int scoreToNextLevel = 10;

    private bool isDead = false;

    public Text scoreText;
    public DeathMenu deathMenu;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            return;
        }
        if(score >= scoreToNextLevel)
        {
            LevelUp();
        }
        score += Time.deltaTime * difficultyLevel;
        scoreText.text = ("Life:" + GetComponent<PlayerMotor>().life).ToString() + "          Score:"+((int)score).ToString();//
    }

    private void LevelUp()
    {
        if(difficultyLevel == maxDifficultyLevel)
        {
            return;
        }
        scoreToNextLevel *= 2;
        difficultyLevel++;
        GetComponent<PlayerMotor>().setSpeed(difficultyLevel);
        GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2Motor>().setSpeed(difficultyLevel);
    }

    public void OnDeath()
    {
        isDead = true;
        if (PlayerPrefs.GetFloat("Highscore") < score)
        {
            PlayerPrefs.SetFloat("Highscore", score);
        }
        deathMenu.ToggleEndMenu(score);
    }

    public void addScore()
    {
        score += 50;

    }
}
