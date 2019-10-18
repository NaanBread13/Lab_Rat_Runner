using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    #region var
    public int isTileSpawner = 0;
    public int isObsSpawner = 0;
    public int isInitialPlatform = 0;

    public int initialPlatformSize =5;
    public int tilePerRow = 9;
    public int spawnRow = 9;
    public float spawnLocationY;
    public float spawnZ = 0.0f;
    public float tileLength = 1.0f;
    public float tileWidth = 1.0f;
    public float tileHeight = 1.0f;
    public float spawnY = 0.0f;
    public int zoneFront = 15;
    public int zoneBehind = 5;
    public int spawnChanceNumerator = 0;
    public int spawnChanceDenominator = 0;
    public int spawnDoorChanceNumerator = 0;
    public int spawnDoorChanceDenominator = 0;
    public int doorSpawnTri = 0;
    public int movingwall = 0;
    public int doorLocation = 0;
    public int triLocation = 0;
    private int rowSpawnedIndex;
    private int colSpawnedIndex = 1;
    public int spawnSpace = 5;

    public Transform PlayerTransform;
    public GameObject[] tilePrefabs;
    public GameObject[] ObsPrefabs;
    private List<GameObject> tileList;
    private List<GameObject> obsList;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        tileList = new List<GameObject>();
        obsList = new List<GameObject>();
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (isInitialPlatform ==1)
        {
            tielGenSys(tilePrefabs, tileList, initialPlatformSize, tilePerRow);
        }
    }
 
    // Update is called once per frame
    void Update()
    {

        if (isTileSpawner == 1)
        {
            if (PlayerTransform.position.z + zoneFront > (tileList[tileList.Count - 1].transform.position.z))
            {
                tielGenSys(tilePrefabs, tileList, 1, spawnRow, tileHeight * spawnY, spawnChanceNumerator, spawnChanceDenominator);
            }
        }
        DeleteTile();
    }

    private void SpawnItem(GameObject[] abcObj, List<GameObject> abcList, float x, float y, float z, int n)
    { 
        if ( x <= spawnRow)
        {
            GameObject abc;
            abc = Instantiate(abcObj[n]) as GameObject;
            abc.transform.SetParent(transform);
            abc.transform.position = new Vector3(x, y, z);
            abcList.Add(abc);
        }
        
    }

    private int ChanceGen(int a, int b)
    {
        if (Random.Range(0, b) < a)
        {
            return 1;
        }
        return 0;
    }

    private void tielGenSys(GameObject[] abcObj, List<GameObject> abcList, int a, int b, float yy = 0.0f, int c = 0, int d = 0)
    {
        for (int i = 0; i < a; i++)
        {
            //PxxxxlayerTransform.position.x
            movingwall = ChanceGen(1, 2);
            rowSpawnedIndex = 0;
            spawnLocationY = -spawnRow;
            doorSpawnTri = ChanceGen(spawnDoorChanceNumerator, spawnDoorChanceDenominator);
          
            doorLocation = Random.Range(0, tilePerRow-4);
            triLocation = Random.Range(0, tilePerRow-2);
            while (triLocation == doorLocation)
            {
                triLocation = Random.Range(0, tilePerRow-4);
            }
            for (int ii = -spawnRow; ii < b; ii++)
            {
                SpawnItem(abcObj, abcList, spawnLocationY + 0.5f, yy, spawnZ, 1);
                if (doorSpawnTri == 0)
                {
                    #region normal obs
                    if (((spawnLocationY + 3) < (spawnRow)) & (colSpawnedIndex == 0) & (ChanceGen(c, d) == 1))
                    {

                        if (ChanceGen(1, 6) == 1)
                        {
                            SpawnItem(abcObj, abcList, spawnLocationY + 0.5f, yy + 1.0f, spawnZ, 2);

                        }
                        else if (ChanceGen(1, 6) == 1)
                        {
                            SpawnItem(abcObj, abcList, spawnLocationY + 0.5f, yy + 1.0f, spawnZ, 3);

                        }
                        else if (ChanceGen(1, 4) == 1 & ((spawnLocationY + 4) < (spawnRow)))//size2
                        {
                            SpawnItem(ObsPrefabs, abcList, spawnLocationY + 1.0f, yy + 1.0f, spawnZ, 3);
                            spawnLocationY += 1;
                            SpawnItem(abcObj, abcList, spawnLocationY + 0.5f, yy, spawnZ, 1);
                            ii += 1;
                        }

                        else
                        {
                            SpawnItem(ObsPrefabs, abcList, spawnLocationY + 0.5f, yy + 1.0f, spawnZ, 0);

                        }


                    }
                    #endregion
                }

                else if (movingwall == 1 )
                {
                    if (((spawnLocationY + 3) < (spawnRow)) &(colSpawnedIndex == 0) & ChanceGen(3,4)==1)
                    {
                        SpawnItem(ObsPrefabs, abcList, spawnLocationY + 0.5f, yy + 1.0f, spawnZ, 4);
                    }
                }

                else
                {
                    #region door obs
                    if (colSpawnedIndex == 0 & spawnLocationY < spawnRow)
                    {
                        if (ii == doorLocation)
                        {
                            SpawnItem(ObsPrefabs, obsList, spawnLocationY + 1.0f, yy + 1.0f, spawnZ, 1);
                            spawnLocationY += 1;
                            SpawnItem(abcObj, abcList, spawnLocationY + 0.5f, yy, spawnZ, 1);
                        }
                        else if (ii == triLocation)
                        {
                            SpawnItem(ObsPrefabs, abcList, spawnLocationY + 0.5f, yy + 0.5f, spawnZ, 2);
                        }
                        else
                        {
                            SpawnItem(ObsPrefabs, abcList, spawnLocationY + 0.5f, yy + 1.0f, spawnZ, 0);
                        }

                    }
                    #endregion
                }
                spawnLocationY += 1;

            }

            spawnZ = tileList[tileList.Count - 1].transform.position.z + tileLength;
            if (colSpawnedIndex < spawnSpace - 1)
            {
                colSpawnedIndex += 1;
            }
            else
            {
                colSpawnedIndex = 0;
            }
            
        }
    }

    private void DeleteTile()
    {
        while (PlayerTransform.position.z - zoneBehind > (tileList[0].transform.position.z))
        {
            if (tileList.Count > 2)
            {
                Destroy(tileList[0]);
                tileList.RemoveAt(0);
                Debug.Log(tileList.Count);
            }
            else
            {
                Debug.Log("toooo fast");
                break;
            }

        }
    }

    public void DeleteObs()
    {
        Destroy(obsList[0]);
        obsList.RemoveAt(0);
    }
}



