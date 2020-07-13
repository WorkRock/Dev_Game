using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_07 : MonoBehaviour
{
    Vector3 target = new Vector3(8, 1.5f, 0);

    void Update()
    {
        /* 1. MoveTowards : 등속이동
         매개 변수는 (현재위치, 목표위치, 속도) 로 구성
         마지막 매개변수에 비례하여 속도 증가
         */
        // transform.position = Vector3.MoveTowards(transform.position,target,1f);

        /* 2. SmoothDamp
        매개 변수는 (현재위치, 목표위치,참조 속도 ,속도) 로 구성
        마지막 매개변수에 반비례하여 속도 증가
        ref : 참조 접근 -> 실시간ㅇ르ㅗ 바뀌는 값 적용 가능
         */
        //Vector3 velo = Vector3.zero;
        // Vector3 velo = Vector3.up * 50; // 위(y축) 으로 가는 값
        // transform.position = Vector3.SmoothDamp(transform.position,target,ref velo,0.1f);

        /* 3. Lerp : 선형 보간, SmoothDamp보다 감속시간이 김
         마지막 매개변수에 비례하여 속도 증가(최대값 1)
         */
        // transform.position = Vector3.Lerp(transform.position, target, 0.05f);

        /* 4. Slerp : 구면 선형 도간, 호를 그리며 이동
         점프한다고 생각하면 편하다 Lerp와 똑같이 마지막 매개변수에 비례해서 속도 증가.
         */
        // transform.position = Vector3.Slerp(transform.position, target, 0.05f);
    }
}
