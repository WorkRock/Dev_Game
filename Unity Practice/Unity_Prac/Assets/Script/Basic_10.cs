using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_10 : MonoBehaviour
{
    Rigidbody rigid;
    void Start() {
        // 1. 컴포넌트 가져오기
        // 코드 흐름 : 선언 - 초기화 - 호출
        rigid = GetComponent<Rigidbody>(); // GetComponent<T> : 자신의 T타입 컴포넌트를 가져옴    
                                           // 3D에 2D컴포넌트를 넣으면 잘안됨. 반대도 마찬가지.

        /* 2. 속도 올리기
        // rigid.velocity = Vector3.right; // velocity : 현재 이동 속도(Vector3)
        rigid.velocity = new Vector3(2, 4, 3);
        */
    }

        // RigidBody 관련 코드는 FixedUpdate에 작성해야 한다 (물리 관련 전부)
        void FixedUpdate() {
         // 3. 힘으로 밀기
        if (Input.GetButtonDown("Jump")) {
            rigid.AddForce(Vector3.up * 5, ForceMode.Impulse); // AddForce의 힘 방향으로 계속 속도 velocity가 증가
            Debug.Log(rigid.velocity); // AddForce(Vec) : Vec의 방향과 크기로 입력 받을때 마다 힘을 줌
                                                           // ForceMode : 힘을 주는 방식 (가속, 무게 반영)
                                                           // Mass의 무게 값이 클수록 움직이는데 더 많은 힘이 필요함
        }

        Vector3 vec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rigid.AddForce(vec, ForceMode.Impulse); 
        

        // 4. 회전력 주기
        //rigid.AddTorque(Vector3.back); // AddTorque(Vec) : Vec 방향을 축으로 회젼력이 생김
    }

    // Basic_11 #2 트리거 이벤트 
    private void OnTriggerStay(Collider other) // 콜라이더가 계속 충돌하고 있을때 호출
    { // 물리적인 충돌이 아니라 콜라이더를 이용한 충돌임
        if (other.name == "Cube")
        {
            rigid.AddForce(Vector3.up * 2, ForceMode.Impulse);
        }
    }

    // Basic_12
    public void Jump()
    {
        rigid.AddForce(Vector3.up * 20, ForceMode.Impulse);
    }
}
