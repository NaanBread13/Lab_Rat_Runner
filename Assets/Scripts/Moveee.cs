using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveee : MonoBehaviour
{

    private float waitTime = 1.0f;
    private float timer = 0.0f;
    private int leftright = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {

            leftright += 1;
            if (leftright > 1)
            {
                leftright = 0;
            }
            // Remove the recorded 2 seconds.
            timer = timer - waitTime - waitTime;


        }
        if (leftright == 0)
        {
            transform.Translate(Vector3.left * Time.deltaTime * 3);
        }
        if (leftright == 1)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 3);
        }
        
    }
}
