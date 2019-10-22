using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public TileManager ti;
    public int popUpIndex = 0;
    public int doorsOpened = 0;
    private DoorController dc;
    private PlayerMotor p1M;
    private Player2Motor p2M;

    /*private bool p1left = false;
    private bool p1right = false;
    private bool p2left = false;
    private bool p2right = false;
    private bool p1jump = false;
    private bool p2jump = false;*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int getIndex()
    {
        return popUpIndex;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (popUpIndex == 0){
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                p1left = true;
            } if (Input.GetKeyDown(KeyCode.RightArrow)){
                p1right = true;
            } if (Input.GetKeyDown(KeyCode.A)) {
                p2left = true;
            } if (Input.GetKeyDown(KeyCode.D)) {
                p2right = true;
            }
        } else if (popUpIndex == 1) {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                p1jump = true;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                p2jump = true;
            }
        }*/


        /*for (int i = 0; i < 3; i++){
            if(i == popUpIndex){
                popUps[popUpIndex].SetActive(true);
                Debug.Log(popUpIndex + " activated");
            }  else if(i != popUpIndex){
                popUps[popUpIndex].SetActive(false);
                Debug.Log(popUpIndex + " deactivated");
            }
        }*/

        if (popUpIndex == 0){
            popUps[popUpIndex].SetActive(true);
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
                Debug.Log("tm");
                GameObject.Find("TileManager").GetComponent<TileManager>().setValue(1);

            }
        } else if (popUpIndex == 1){
            popUps[popUpIndex].SetActive(true);
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
                GameObject.Find("TileManager").GetComponent<TileManager>().setValue(2);
            }
        } else if(popUpIndex == 2){
            popUps[popUpIndex].SetActive(true);
            doorsOpened = GameObject.Find("TileManager").GetComponent<TileManager>().getGates();

            if (doorsOpened > 10)
            {
                
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
            }
            //FIGURE OUT GATE TUTORIAL, MAYBE HAVE A VAR THAT COUNTS HOW MANY TIMES THE BUTTON TO OPNE GATE HAS BEEN PRESSED
        } else if(popUpIndex == 3)
        {
            popUps[popUpIndex].SetActive(true);
            //p1M.setSpeed(0);
            //p2M.setSpeed(0);
            GameObject.Find("TileManager").GetComponent<TileManager>().setValue(0);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("escape");
                UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");

            }
        } 
        

        
    }
}
