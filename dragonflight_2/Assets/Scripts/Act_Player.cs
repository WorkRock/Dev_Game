using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act_Player : MonoBehaviour {

	public float Player_Speed = 3.0f;			// 플레이어가 움직이는 속도
	
	public GameObject Parents_Bullet = null;	// 총알의 부모
	public GameObject Bullet = null;			// 총알의 프리팹 넣을 곳
	public float CoolTime = 0.15f;				// 총알이 발사되는 쿨타임
	GameObject Prefabs_Bullet = null;			// 프리팹을 instantiate 할 변수
	float fdt = 0f;
	void Update () {
		fdt += Time.deltaTime;	// 플로트 델타 타임 이라는 변수에 델타 타임을 더해줘서 프레임간 간격을 맞추는 것
		Move();
		Shot();
	}

	void Move()					// 이 함수는 왼쪽, 오른쪽 화살표를 눌렀을 때 플레이어가 움직이게 함
	{
        if (gameObject.transform.localPosition.x > -3.2f)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                gameObject.transform.localPosition =
                new Vector3(gameObject.transform.localPosition.x - Player_Speed * Time.deltaTime,
                gameObject.transform.localPosition.y,
                gameObject.transform.localPosition.z);
        }

        if (gameObject.transform.localPosition.x < 3.2f)
        {
            if (Input.GetKey(KeyCode.RightArrow))
                gameObject.transform.localPosition =
                new Vector3(gameObject.transform.localPosition.x + Player_Speed * Time.deltaTime,
                gameObject.transform.localPosition.y,
                gameObject.transform.localPosition.z);
        }
	}

	void Shot()					// 이 함수는 쿨타임이 될 때 마다 총알을 생성함
	{
		if (fdt > CoolTime)
		{
			Prefabs_Bullet = Instantiate(Bullet);
			Prefabs_Bullet.transform.parent = Parents_Bullet.transform;
			Prefabs_Bullet.transform.localPosition =
			new Vector3(gameObject.transform.localPosition.x,
			gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

			fdt = 0.0f;
		}
	}
}
