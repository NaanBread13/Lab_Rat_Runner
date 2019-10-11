using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Customization : MonoBehaviour
{
    public GameObject[] ObsPre; // list of Object prefabs
    public int prefabPlayermodelIndex = 0; // index of prefabs;
    private List<GameObject> opList; // list of Object Prefabs
    private int playerModelInteger = PlayerPrefs.GetInt("Player2Model");

    // Start is called before the first frame update
    void Start()
    {
        opList = new List<GameObject>();
        setSpawn(playerModelInteger);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setSpawn(int justforfunDoesNothing)
    {
        DeleteTile();
        Debug.Log("setspawnrrr");
        if (prefabPlayermodelIndex == 2)
        {
            prefabPlayermodelIndex = 0;
        }

        SpawnItem(ObsPre, opList, 0f, 1.2f, 0f, prefabPlayermodelIndex);

        prefabPlayermodelIndex += 1;
    }

    private void SpawnItem(GameObject[] abcObj, List<GameObject> abcList, float x, float y, float z, int n)
    {
        GameObject abc;
        abc = Instantiate(abcObj[n]) as GameObject;
        abc.transform.SetParent(transform);
        abc.transform.position = new Vector3(x, y, z);
        abcList.Add(abc);
    }

    private void DeleteTile()
    {

        if (opList.Count > 0)
        {
            Destroy(opList[0]);
            opList.RemoveAt(0);
            Debug.Log(opList.Count);
        }
        else
        {
            Debug.Log("nothingto delete");
        }


    }
}
