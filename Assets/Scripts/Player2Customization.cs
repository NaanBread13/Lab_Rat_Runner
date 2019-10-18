using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Customization : MonoBehaviour
{
    public GameObject[] ObsPre; // list of Object prefabs
    private List<GameObject> opList; // list of Object Prefabs
    private int playerModelInteger;

    // Start is called before the first frame update
    void Start()
    {
        playerModelInteger = PlayerPrefs.GetInt("Player2Model");
        opList = new List<GameObject>();
        setSpawn(playerModelInteger);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setSpawn(int justforfunDoesNothing)
    {
        Debug.Log("setspawnrrr");

        SpawnItem(ObsPre, opList, 2f, 1.0f, 0f, justforfunDoesNothing);
    }

    private void SpawnItem(GameObject[] abcObj, List<GameObject> abcList, float x, float y, float z, int n)
    {
        GameObject abc;
        abc = Instantiate(abcObj[n]) as GameObject;
        abc.transform.SetParent(transform);
        abc.transform.position = new Vector3(x, y, z);
        abcList.Add(abc);
    }

}
