using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_05 : MonoBehaviour
{
    // 1. 초기화 영역 [Awake, Start]
    void Awake() // 게임 오브젝트 생성할 때, 최초 실행
    {
        Debug.Log("플레이어 데이터가 준비되었습니다.");    
    }

    void Start() // 업데이트 시작 직전, 최초 실행
    {
        Debug.Log("사냥 장비를 챙겼습니다.");
    }


    // 5. 활성화
    void OnEnable() // 최초 1회 실행이 아닌 껴고 키고 할때마다 실행 (Awake보다는 늦고 Start보다는 빠르다)
    {
        Debug.Log("플레이어 로그인을 확인하였습니다.");
    }

    // 2. 물리 연산
    void FixedUpdate() // 물리 연산을 하기전에 실행되는 업데이트 함수
    // 고정된 실행 주기로 CPU를 많이 사용(60FPS 고정)
    {
        Debug.Log("이동~");
    }


    // 3. 게임 로직
    void Update() // 물리연산과 관련된 로직을 제외한 주기적으로 변하는 로직을 넣을때 사용하는 업데이트 함수
    // 환경(컴퓨터)에 따라 실행 주기가 떨어질 수 있음
    {
        Debug.Log("몬스터 사냥~");
    }

    void LateUpdate() // 모든 업데이트 끝난 후 
        // 캐릭터를 따라가는 카메라 같은 오브젝트에 주로 사용
    {
        Debug.Log("경험치 획득.");
    }


    // 5. 비활성화
    void OnDisable() // 모든 업데이트가 끝나고 오브젝트가 비활성화 되거나 삭제될 때 실행
    {
        Debug.Log("플레이어 로그아웃이 확인되었습니다.");
    }



    // 4. 해체
    void OnDestroy() // 해당 오브젝트가 삭제 직전에 무언가 남기고 삭제됨
    {
        Debug.Log("플레이어 데이터를 해체하였습니다.");
    }
}
