using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mng_monster : MonoBehaviour {

	float fdt = 0.0f;	// float delta time 의 줌말
	public float Monster_Cooltime = 3.0f;	// 몬스터 생성 쿨타임
	
	public GameObject Monsters;				// 몬스터의 프리팹을 놓을 곳
	public GameObject Parents_Monsters;		// 몬스터의 부모를 놓을 곳
	GameObject Prefabs_Monsters; 			// 몬스터를 생성할 변수

	// Update is called once per frame
	void Update () {
		fdt += Time.deltaTime;

		if (fdt > Monster_Cooltime)		// 델타타임이 쿨타임보다 크면
			CreateMonster(); 	// 몬스터생성 함수 실행
	}

	void CreateMonster()		// 몬스터생성 함수
	{
		fdt = 0.0f;			// 델타타임 초기화
		Prefabs_Monsters = Instantiate(Monsters);
		Prefabs_Monsters.transform.parent = Parents_Monsters.transform;
		Prefabs_Monsters.transform.localScale = new Vector3(1,1,1);
		Prefabs_Monsters.transform.localPosition = new Vector3(0, 6.5f, 0);
	}
}
