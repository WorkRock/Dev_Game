using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act_bullet : MonoBehaviour {

	public float Bullet_Speed = 7.0f;		// 총알의 속도

	void Update () {
		// 총알이 위로 올라가는 코드
		gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,
		gameObject.transform.localPosition.y + Bullet_Speed * Time.deltaTime,
		gameObject.transform.localPosition.z);


		// 총알이 일정수준 위로 올라갔으면 삭제해주는 코드
		if (gameObject.transform.localPosition.y > 8.0f)
			Destroy(gameObject);
	}
}
