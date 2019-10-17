using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public int popUpIndex = 0;
    //public GameObject tileFlat;
    //public GameObject tileObs;
    //public GameObject tileGate;

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


        for (int i = 0; i < popUps.Length; i++){
            if(i == popUpIndex){
                //popUps[popUpIndex].SetActive(true);
            }  else{
                //popUps[popUpIndex].SetActive(false);
            }
        }

        if (popUpIndex == 0){
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            { 
                popUpIndex++;
                Debug.Log("tm");
                GameObject.Find("TileManager").GetComponent<TileManager>().setValue(1); 

                //spawner.SetActive(true);
                //consider making 3 spawners, one for each tutorial tile

            }
        } else if (popUpIndex == 1){
            if(Input.GetKeyDown(KeyCode.UpArrow)) { 
                popUpIndex++;
                GameObject.Find("TileManager").GetComponent<TileManager>().setValue(2);
            }
        } else if(popUpIndex == 2)
        {
             //FIGURE OUT GATE TUTORIAL, MAYBE HAVE A VAR THAT COUNTS HOW MANY TIMES THE BUTTON TO OPNE GATE HAS BEEN PRESSED
        }
        
    }
}
