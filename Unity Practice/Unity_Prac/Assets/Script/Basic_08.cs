using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_08 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* Time.deltaTime : 이전 프레임의 완료까지 걸린 시간
         deltaTime값은 프레임이 적으면 크고, 프레임이 많으면 작음
        사용법
         1. Translate : 벡터에 곱하기
         ex) transform.Translate(Vec * Time.deltaTime);
         
         2. Vector 함수 : 시간 매개변수에 곱하기
         ex) Vector3.Lerp(Vec1, Vec2, T * Time.deltaTime);
         */
    }
}
