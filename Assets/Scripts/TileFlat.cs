using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFlat : MonoBehaviour
{
    public GameObject tile;

    // Update is called once per frame
    void Update()
    {
        Instantiate(tile);
    }
}
