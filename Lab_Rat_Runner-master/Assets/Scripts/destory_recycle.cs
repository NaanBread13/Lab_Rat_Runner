using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destory_recycle : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "floor")
        {
            Debug.Log("hit floor");
            Destroy(other.gameObject);
        }

    }
}