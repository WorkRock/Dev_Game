using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_11 : MonoBehaviour
{
    MeshRenderer mesh; // 오브젝트의 재질 접근은 MeshRenderer을 통해서
    Material mat;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
    }

    // CollisionEnter : 물리적 충돌이 시작할 때 호출되는 함수
    private void OnCollisionEnter(Collision collision) // Collision : 충돌 정보 클래스
    {
        if(collision.gameObject.name == "My_Ball")
            mat.color = new Color(0, 0, 0);
    }

    // CollisionStay : 물리적 충돌이 일어나고 있을때 호출되는 함수
    private void OnCollisionStay(Collision collision)
    {
        
    }


    // CollisionExit : 물리적 충돌이 끝날때 호출되는 함수
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "My_Ball")
            mat.color = new Color(1, 1, 1);
    }
}
