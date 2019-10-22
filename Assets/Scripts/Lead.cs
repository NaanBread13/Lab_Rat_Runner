using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;


public class Lead : MonoBehaviour
{
    // Start is called before the first frame update
    //public DeathMenu deathMenu;
    public Text no1;
    public Text no2;
    public Text no3;
    public Text no4;
    public Text no5;
    string S;
    Hashtable tb;
    int n1;
    int n2;
    int n3;
    int n4;
    int n5;
    int n0=0;
    List<int> ls = new List<int> { };
    void Start()
    {
        //PlayerPrefs.DeleteKey("scoreS");
        //PlayerPrefs.SetInt("scoreR", 10);
        Debug.Log("THE recorded score is"+PlayerPrefs.GetInt("scoreR"));
        Debug.Log("datas found"+PlayerPrefs.HasKey("scoreS"));
        if (!PlayerPrefs.HasKey("scoreS"))
        {
            PlayerPrefs.SetString("scoreS", "0a0a0a0a0");

        }
        translate();
        ls.Add(n1);
        ls.Add(n2);
        ls.Add(n3);
        ls.Add(n4);
        ls.Add(n5);
        ////if (PlayerPrefs.HasKey("scoreR"))
        ////{
        //newNum();
        ////}
    }

    // Update is called once per frame
    void Update()
    {

        loading();
        //no1.text = n1.ToString();
        //no2.text = n2.ToString();
        //no3.text = n3.ToString();
        //no4.text = n4.ToString();
        //no5.text = n5.ToString();
    }
    public void inPutNum()
    {
        n0 = PlayerPrefs.GetInt("scoreR");
        if (!ls.Contains(n0))
        {
            ls.Add(n0);
            //ls = ls.OrderByDescending(v => v).ToList();


            ls.Sort(
    delegate (int a, int b)
    {
        return a.CompareTo(b);
    }
);
                ls.Sort((a, b) => b.CompareTo(a));
            

            Debug.Log("new score added");
            ls.RemoveAt(5);
        }
    }
    public void newNum()
    {
        n0 = PlayerPrefs.GetInt("scoreR");
        //Debug.Log(n0);
        //Debug.Log(n5);
        //Debug.Log(Swap(n0, n5));
        if (Swap(n0, n5))
        {
            n0 += n5;
            n5 = n0 - n5;
            n0 -= n5;
            if (Swap(n5, n4))
            {
                n5 += n4;
                n4 = n5 - n4;
                n5 -= n4;
                if (Swap(n4, n3))
                {
                    n4 += n3;
                    n3 = n4 - n3;
                    n4 -= n3;
                    //doSwap(n4, n3);
                    if (Swap(n3, n2))
                    {
                        n3 += n2;
                        n2 = n3 - n2;
                        n3 -= n2;
                        //doSwap(n3, n2);
                        if (Swap(n2, n1))
                        {
                            n2 += n1;
                            n1 = n2 - n1;
                            n2 -= n1;
                            //doSwap(n2, n1);
                            Debug.Log("we got a new champian!");
                            S = n1 + "a" + n2 + "a" + n3 + "a" + n4 + "a" + n5;
                            PlayerPrefs.SetString("scoreS", S);
                        }
                    }
                }
            }
        }
    }
    public void loading()
    {
        ls = ls.OrderByDescending(v => v).ToList();
        no1.text = ls[0].ToString();
        no2.text = ls[1].ToString();
        no3.text = ls[2].ToString();
        no4.text = ls[3].ToString();
        no5.text = ls[4].ToString();
        PlayerPrefs.SetString("scoreS", ls[0] + "a" + ls[1] + "a" + ls[2] + "a" + ls[3] + "a" + ls[4]);
    }
    public void translate()
    {
        string[] a;
        char c = 'a';
        string b = PlayerPrefs.GetString("scoreS");
        a = b.Split(c);
        n1 = int.Parse(a[0]);
        n2 = int.Parse(a[1]);
        n3 = int.Parse(a[2]);
        n4 = int.Parse(a[3]);
        n5 = int.Parse(a[4]);
    }
    public void doSwap(int a, int b)
    {
        int tem = 0;
        tem = a;
        a = b;
        b = tem;
    }
    public bool Swap(int a, int b)
    {        
        if (a>b)
        {
            return true;
            
        }
        else {return false; }
        
    }
    //public void outPutDatas()
    //{
    //    //deathMenu.LoadData();
    //}
    //public void outPutData()
    //{
    //    int score = PlayerPrefs.GetInt("ScoreR");
    //    Debug.Log(score);
    //    print(score);
    //}
    //public void ronasaveway()
    //{
    //    //newNum();
    //    PlayerPrefs.SetInt("NO1", n1);
    //    PlayerPrefs.SetInt("NO2", n2);
    //    PlayerPrefs.SetInt("NO3", n3);
    //    PlayerPrefs.SetInt("NO4", n4);
    //    PlayerPrefs.SetInt("NO5", n5);

    //    PlayerPrefs.GetInt("NO1", n1);
    //    PlayerPrefs.GetInt("NO2", n2);
    //    PlayerPrefs.GetInt("NO3", n3);
    //    PlayerPrefs.GetInt("NO4", n4);
    //    PlayerPrefs.GetInt("NO5", n5);


    //}
    
}
