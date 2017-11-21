using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act_monster : MonoBehaviour {

	public float Monster_Speed = 6.0f;		// 몬스터의 속도

    public GameObject HP_Mons;

    float Full_Hp = 4f;

    float HP = 0f;

    float HP_bar = 1f;

    public float Monster_Cooltime = 3.0f;

    public GameObject item_coin;
    public GameObject Parents_Coins;
    GameObject Prefabs_Coins;

    public GameObject dust;
    public GameObject Parents_Dusts;
    GameObject Prefabs_Dusts;
    int ItemChoose = 0;



    Act_Score monScore = new Act_Score();
    

    void Awake()
    {
        HP = Full_Hp;
    }

	void Update () {
        // 몬스터가 아래로 내려가는 코드
        if(gameObject.transform.localPosition.y < 3.0f)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,
            gameObject.transform.localPosition.y - Monster_Speed * Time.deltaTime,
            gameObject.transform.localPosition.z);
        }

        

		// 몬스터가 일정수준 아래로 내려갔으면 삭제해주는 코드
		if (gameObject.transform.localPosition.y < -15.0f)
			Destroy(gameObject);
	}

	void OnTriggerEnter(Collider Col)
	{
		if (Col.tag == "Bullet")
		{
            Destroy(Col.gameObject);
            MonsterHit();
        }

        else if(Col.tag == "Player")
        {
            Destroy(Col.gameObject);
            HP -= 3;
            MonsterHit();
        }
	} 

    void MonsterHit()
    {
        HP -= 1;
        if (HP.Equals(0))
        {
            Destroy(gameObject);
            DropItem();
        }
        else
        {
            HP_bar = HP / Full_Hp;
            HP_Mons.transform.localScale = new Vector3(HP_bar, 1f, 1f);
        }
            
    }

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


    void DropDust()
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
