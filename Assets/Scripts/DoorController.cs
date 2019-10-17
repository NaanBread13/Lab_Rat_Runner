using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject Door;
    /*public bool doorIsOpening;

    private void Start()
    {
       Door  = GameObject.FindGameObjectWithTag("Door");
    }

    // Update is called once per frame
    void Update()
    {
        if(doorIsOpening == true)
        {
            Door.transform.Translate(Vector3.left * 5);
        }

        if(Door.transform.position.x > 7f)
        {
            doorIsOpening = false;
        }
    */

    private void OnTriggerEnter(Collider player)
    {
        Door.transform.position += new Vector3(0, -4, 0);
    }
}
