using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bb : MonoBehaviour
{
    /// <summary>
    /// get GameObject id from the testb, pass it into the game scene so in runtime that it goes and accesses the object.
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        

   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dasfdfadf()
    {
       
        GameObject.Find("GameObject").GetComponent<testb>().setSpawn(0);
      
    }

    public void player1Select()
    {
        int chosenPlayer = GameObject.Find("GameObject").GetComponent<testb>().getIndex();
        PlayerPrefs.SetInt("Player1Model", chosenPlayer);
        Debug.Log(chosenPlayer);
    }

    public void player2Select()
    {
        int chosenPlayer = GameObject.Find("GameObject").GetComponent<testb>().getIndex();
        PlayerPrefs.SetInt("Player2Model", chosenPlayer);
    }
}
