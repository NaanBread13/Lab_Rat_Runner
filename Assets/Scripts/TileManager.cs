using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private Transform PlayerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 10.0f;
    private int amountTilesOnScreen = 7;
    public int tileAmount = 0;
    private float safeZone = 15.0f;
    public int lastPrefabIndex = 0;
    public int test = 0;
    private int gates = 0;

    private List<GameObject> activeTiles;
    // Start is called before the first frame update
    private void Start()
    {
        activeTiles = new List<GameObject>();
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amountTilesOnScreen; i++)
        {
            if (i < 2)
            {
                SpawnTile(false);
            }
            SpawnTile(false);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //setValue(1);
        //Debug.Log("update test" + test);
        if (tileAmount < 7)
        {
            if (PlayerTransform.position.z - safeZone > (spawnZ - amountTilesOnScreen * tileLength))
            {
                SpawnTile(false);
                lastPrefabIndex++;
                SpawnTile(false);
                lastPrefabIndex++;
                SpawnTile(true);
                lastPrefabIndex++;
                
            }
        }

        if (PlayerTransform.position.z - safeZone > (spawnZ - amountTilesOnScreen * tileLength))
        {
            DeleteTile();
            lastPrefabIndex--;
        }
        }
    /*
    public int setValue(int value)
    {
        Debug.Log("set value " + value);
        test = value;
        Debug.Log("set test " + test);

        return test;
    }
    */
    public void setValue(int value)
    {
        test = value;
    }

    public int getGates()
    {
        return gates;
    }

    private void SpawnTile(bool obs){
        GameObject go;
        tileAmount++;
        if (obs)
        {
            //for(int i = 0; i < 5; i++)
            //{
                int j = lastPrefabIndex;
            Debug.Log(j);
                //activeTiles.RemoveRange(j - 5, 5);
            //lastPrefabIndex -= 5;
            //}
            //Debug.Log("spawn " + test);
            go = Instantiate(tilePrefabs[test]) as GameObject;
            //go = Instantiate(tilePrefabs[tm.getIndex()]) as GameObject;
            if(test == 2)
            {
                gates++;
            }
            go.transform.SetParent(transform);
            go.transform.position = new Vector3(0, 0, 1 * spawnZ);
            spawnZ += tileLength;
            activeTiles.Add(go);
        } else
        {
            go = Instantiate(tilePrefabs[0]) as GameObject;
            //go = Instantiate(tilePrefabs[tm.getIndex()]) as GameObject;

            go.transform.SetParent(transform);
            go.transform.position = new Vector3(0, 0, 1 * spawnZ);
            spawnZ += tileLength;
            activeTiles.Add(go);
        }
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
        tileAmount--;
    }
    /*
    private int RandomPrefabIndex()
    {
        if (tm.getIndex() == 0) {
            return 0;
        } else if(tm.getIndex() == 1)
        {
            return 1;
        } else if(tm.getIndex() == 3)
        {
            return 2;
        }

        return 0;
    }*/
}
