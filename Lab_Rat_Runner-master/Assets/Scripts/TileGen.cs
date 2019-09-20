using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGen : MonoBehaviour
{
    #region var
    public GameObject[] tilePrefabs;

    public float spawnZ = 0.0f;
    public float tileLength = 10.0f;

    public float safeZone = 15.0f;
    public int lastPrefabIndex = 0;
    public float spawnX = 0;
    public float tileWidth = 1.0f;
    public int spawnW_target = 9;
    public int spawnW_index = 0;
    public float show_player_z;
    public float show_player_x;


    private List<GameObject> activeTiles;
    public Transform PlayerTransform;
    public int amountTilesOnScreen = 7;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amountTilesOnScreen; )
        {
            if (i < 2)
            {
                SpawnTile(0);
            }
            SpawnTile();
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTransform.position.z - safeZone > (spawnZ - amountTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    //
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;

        spawnW_index = (0 - (spawnW_target / 2));
        while (spawnW_index <= spawnW_target / 2)
        {

            if (prefabIndex == -1)
            {
                go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
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
        spawnZ += tileLength;


    }

    //
    private void DeleteTile()
    {
        for (int i = 3; i < spawnW_target; i++)
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }

    }

    //
    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
        {
            return 0;
        }
        int RandomIndex = lastPrefabIndex;

        while (RandomIndex == lastPrefabIndex)
        {
            RandomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = RandomIndex;
        return RandomIndex;
    }

}
