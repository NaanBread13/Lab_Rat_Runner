using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

    public int NextLevel()
    {
  
        scoreToNextLevel *= 2;
        difficultyLevel++;
        return difficultyLevel;
    }
    public int GetLevel()
    {
        return difficultyLevel;
    }
    public int LastLevel()
    {
        scoreToNextLevel /= 2;
        difficultyLevel--;
        return difficultyLevel;
    }

    public void OnDeath()
    {
        isDead = true;
        if (PlayerPrefs.GetFloat("Highscore") < score)
        {
            PlayerPrefs.SetFloat("Highscore", score);
        }
        deathMenu.ToggleEndMenu(score);
        //Collecting();
    }

    public float getHighScore()
    {
        return PlayerPrefs.GetFloat("Highscore");
    }

    //public void Collecting()
    //{
    //    int nc = 0;
    //    if (isDead)
    //    {
    //        nc +=1;
    //    }
    //    if (nc==1)
    //    {
    //        int i;
    //        i = (int)score;
    //        string path = "Assets/test.txt";
    //        StreamWriter writer = new StreamWriter(path, true);
    //        writer.WriteLine(i);
    //        writer.Close();
    //    }
    //}
    public void addScore()
    {
        score += 50;

    }
}
