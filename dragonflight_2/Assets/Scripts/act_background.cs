using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class act_background : MonoBehaviour {
	public float Background_Speed = 1.0f; 		// 배경화면 움직이는 속도 퍼블릭 형으로 선언
	
	// Update is called once per frame
	void Update () {
		// 배경화면이 아래로 이동하는 코드
		gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,
		gameObject.transform.localPosition.y - Background_Speed * Time.deltaTime,
		gameObject.transform.localPosition.z);


		// 배경화면이 일정수준으로 내려가면 다시 위로 올려주는 코드
		if (gameObject.transform.localPosition.y < -9.2f)
			gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,
			11.2f, gameObject.transform.localPosition.z);
	}
}
