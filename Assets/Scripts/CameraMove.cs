using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float movingSpeed = 5f;
    Vector3 p;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p = transform.position;
        p.x=(GameObject.FindGameObjectWithTag("Player").transform.position.x + GameObject.FindGameObjectWithTag("Player2").transform.position.x) / 2;
        transform.position = p;
    }
}
