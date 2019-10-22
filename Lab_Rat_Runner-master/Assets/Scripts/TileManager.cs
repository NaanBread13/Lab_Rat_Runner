using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    #region var
    public GameObject[] tilePrefabs;
    public GameObject[] ObsPrefabs;
    public Transform PlayerTransform;
    public float spawnZ = 0.0f;
    public float tileLength = 10.0f;
    public int initialPlatformSize = 7;
    public int spaceObs = 7;
    private int spaceIndex = 0;
    public float safeZone = 15.0f;
    public float safeZoneBack = 15.0f;
    public int lastPrefabIndex = 0;
    public float spawnX = 0;
    public float tileWidth = 1.0f;
    public int spawnW_target = 9;

    public int maxiumObsRow = 0;
    public int spawnW_index = 0;
    public int spawnChance = 1; 
    private List<GameObject> activeTiles;
    private List<GameObject> activeObsPrefabs;
    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        activeTiles = new List<GameObject>();
        activeObsPrefabs = new List<GameObject>();
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i < initialPlatformSize; i++)
        {
            SpawnTile(0);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (PlayerTransform.position.z + safeZone > (activeTiles[activeTiles.Count - 1].transform.position.z))
        {
            SpawnTile();
            DeleteTile();
            DeleteObs();
        }

    }

    private void SpawnTile(int prefabIndex = -1)
    {
        maxiumObsRow = 0;
        if (spaceIndex < spaceObs)
        {
            spaceIndex += 1;
        }
        else
        {
            spaceIndex = 0;
        }
        GameObject go;

        spawnW_index = (0 - (spawnW_target / 2));

        while (spawnW_index <= spawnW_target / 2)
        {

            if (prefabIndex == -1)
            {
                go = Instantiate(tilePrefabs[RandomPrefabIndex(1)]) as GameObject;
                if(RandomObs(-1) == 0 & spaceIndex == 0 & maxiumObsRow < spawnW_target)
                {
                    maxiumObsRow += 1;
                    SpawnObs();
                }

            }
            else
            {
                go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
            }

            go.transform.SetParent(transform);
            go.transform.position = new Vector3(tileWidth * spawnW_index + (float)PlayerTransform.position.x, 0.0f, 1.0f * spawnZ);
            spawnW_index += 1;
            activeTiles.Add(go);

        }
        spawnW_index = 0;
        spawnZ = activeTiles[activeTiles.Count - 1].transform.position.z + tileLength;

    }
    private void SpawnObs()
    {
        GameObject gogogo;
        gogogo = Instantiate(ObsPrefabs[RandomObs()]) as GameObject;
        gogogo.transform.SetParent(transform);
        gogogo.transform.position = new Vector3(tileWidth * spawnW_index + (float)PlayerTransform.position.x, 1.0f, 1.0f * spawnZ);
        activeObsPrefabs.Add(gogogo);

    }



    private void DeleteTile()
    {
        while (PlayerTransform.position.z - safeZoneBack > (activeTiles[0].transform.position.z))
        {
            if (activeTiles.Count > 2)
            {
                Destroy(activeTiles[0]);
                activeTiles.RemoveAt(0);
                Debug.Log(activeTiles.Count);
            }
            else
            {
                Debug.Log("toooo fast");
                break;
            }

        }
    }
    private void DeleteObs()
    {
        while (PlayerTransform.position.z - safeZoneBack > (activeObsPrefabs[0].transform.position.z))
        {
            if (activeObsPrefabs.Count > 2)
            {
                Destroy(activeObsPrefabs[0]);
                activeObsPrefabs.RemoveAt(0);
            }
            else
            {
                Debug.Log("toooo fast");
                break;
            }
        }
    }


    private int RandomPrefabIndex(int preIndex)
    {

        if (tilePrefabs.Length <= 1)
        {
            return 0;
        }
        int RandomIndex = lastPrefabIndex;

        while(RandomIndex == lastPrefabIndex)
        {
            RandomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = RandomIndex;
        return RandomIndex;
    }

    private int RandomObs(int abc = 1)
    {
        if (abc == -1)
        {
            abc = Random.Range(0, spawnChance);
            return abc;
        }
        else
        {
            abc = Random.Range(0, ObsPrefabs.Length);
            return abc;
        }
    }
}
