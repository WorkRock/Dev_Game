using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mng_Item : MonoBehaviour {

    public GameObject item_coin;
    public GameObject Parents_Coins;
    GameObject Prefabs_Coins;

    public GameObject dust;
    public GameObject Parents_Dusts;
    GameObject Prefabs_Dusts;
    int ItemChoose = 0;

    void DropItem()
    {
        ItemChoose = Random.Range(0, 2);
        if (ItemChoose.Equals(0))
            DropDust();
        else
            DropCoin();
    }

    void DropCoin()
    {
        Prefabs_Coins = Instantiate(dust);
        Prefabs_Coins.transform.parent = Parents_Coins.transform;
        Prefabs_Coins.transform.localScale = new Vector3(1, 1, 1);
        Prefabs_Coins.transform.localPosition = gameObject.transform.position;
    }


    void DropDdust()
    {
        int dustNum = Random.Range(2, 5);
        float dustFlo = Random.Range(0.6f, 0.8f);
        int i = 0;
        for (i = 0; i < dustNum; i++)
        {
            Prefabs_Dusts = Instantiate(dust);
            Prefabs_Dusts.transform.parent = Parents_Dusts.transform;
            Prefabs_Dusts.transform.localScale = new Vector3(dustFlo, dustFlo, dustFlo);
            Prefabs_Dusts.transform.localPosition = gameObject.transform.position;
        }
    }
}
