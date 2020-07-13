using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_06 : MonoBehaviour
{
    /*
    void Start()
    {
        Vector3 vec = new Vector3(5, 0, 0);
        transform.Translate(vec); // Translate : 괄호의 벡터값을 현재 위치에 더하는 함수   
        // Vector3 : 우리가 하는 수학 벡터. xyz축. Vector2를 쓰면 2차원

        // int number = 4; // 단순 변수를 '스칼라'라고 함
        
    }
    */

    void Update()
    {
        // Transform : 오브젝트 형태에 대한 기본 컴포넌트. 오브젝트는 변수 transform을 항상 가지고 있음.

        // Input : 게임 내 입력을 관리하는 클래스
        // 유니티내에 Edit -> Project Setting -> Input 들어가서 변경가능
        /*
        // anyKey : 아무키나 입력받으면 true
        if (Input.anyKeyDown) // 아무 입력을 최초로 받을때 true(호출됨)
            Debug.Log("플레이어가 아무키를 눌렀슴다");
        if (Input.anyKey) // 아무 입력을 받고 있으면 true(호출됨)
            Debug.Log("플레이어가 아무키를 누르고 있습니다"); */

        /*
        // GetKey : 키보드 버튼 입력을 받으면 true
        if (Input.GetKeyDown(KeyCode.Return)) // Return = 엔터키
            Debug.Log("아이템 구입 완료");
        if (Input.GetKey(KeyCode.LeftArrow))
            Debug.Log("왼쪽으로 이동 중");
        if (Input.GetKeyUp(KeyCode.RightArrow)) // Up : 손을 땟을때 발생하는 함수
            Debug.Log("오른쪽 이동을 멈추었습니다.");
        */

        /*
        // GetMouse : 마우스 버튼 입력을 받으면 true
        if (Input.GetMouseButtonDown(0)) // Return = 엔터키
            Debug.Log("미사일 발사");
        if (Input.GetMouseButton(0))
            Debug.Log("충전중...");
        if (Input.GetMouseButtonUp(0)) // Up : 손을 땟을때 발생하는 함수
            Debug.Log("충전 완료");
        */

        /*
        // GetButton : Input버튼 입력을 받으면 true
        if (Input.GetButtonDown("Jump")) // Return = 엔터키
            Debug.Log("점프 준비");
        if (Input.GetButton("Jump"))
            Debug.Log("점프 차징..");
        if (Input.GetButtonUp("Jump")) // Up : 손을 땟을때 발생하는 함수
            Debug.Log("점프!");
        */

        /*
        if (Input.GetButton("Horizontal")){
            Debug.Log("점프 준비" + Input.GetAxis("Horizontal"));
             // GetAxis : 수평, 수직 버튼 입력을 받으면 float값 반환
        }
        */

        /*
        if (Input.GetButton("Horizontal"))
        {
            Debug.Log("점프 준비" + Input.GetAxis("Horizontal"));
            // 오브젝트는 변수 transform을 항상 가지고 있다
            // GetAxisRaw : 소숫값이 아닌 정수값으로 나옴
        }
        */

        Vector3 vec = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.Translate(vec);
    }
}
