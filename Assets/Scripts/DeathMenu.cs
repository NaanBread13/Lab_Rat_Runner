using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class DeathMenu : MonoBehaviour
{
    public Text scoreText;
    public Image backgroundImage;
    private int rs;
    public lead ld;

    public  bool isShown = false;
    private float transition = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isShown)
        {
            return;
        }

        transition += Time.deltaTime;
        backgroundImage.color = Color.Lerp(new Color(0,0,0,0), Color.black,transition);
    }

    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        rs = ((int)score);
        scoreText.text = rs.ToString();
        isShown = true;
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Savedata()
    {
        Debug.Log("datas saved" + rs);
        PlayerPrefs.SetInt("scoreR", rs);
        ld.inPutNum();
        //ld.newNum();
    }
    public void LoadData()
    {
        int score = PlayerPrefs.GetInt("ScoreR");
        Debug.Log(score);
        print(score);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
        GameObject gameObject = GameObject.FindGameObjectWithTag("Music");
        Destroy(gameObject);
      
    }
}
