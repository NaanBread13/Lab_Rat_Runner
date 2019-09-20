using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destory_recycle : MonoBehaviour
{
    void OnTriggerEnter(Collider ot)
    {
        Debug.Log(ot.gameObject.tag);
        if (ot.gameObject.tag == "tri")
        {   ot.gameObject.tag = "trash";

            GameObject go = GameObject.Find("TileManager");
            ItemSpawner other = (ItemSpawner)go.GetComponent(typeof(ItemSpawner));
            other.DeleteObs();
        }

        if (ot.gameObject.tag == "coin")
        {
            ot.gameObject.tag = "trash";
            string ScriptName = "MoveUp";
            System.Type MyScriptType = System.Type.GetType(ScriptName + ",Assembly-CSharp");
            ot.gameObject.AddComponent(MyScriptType);
            GetComponent<Score>().addScore();

            GameObject go = GameObject.Find("Player");
            PlayerMotor other = (PlayerMotor)go.GetComponent(typeof(PlayerMotor));
            other.setLife(1);
        }
            
            

    }
}


