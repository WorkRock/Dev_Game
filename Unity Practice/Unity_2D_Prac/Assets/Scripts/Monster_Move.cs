using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Move : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    public int nextMove; // 행동지표를 결정하는 변수
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Think();
        //Invoke("Think", 5); // Invoke() : 주어진 시간이 지난 뒤, 지정된 함수를 실행하는 함수
    }

    void FixedUpdate() // 물리 기반일 시 FixedUpdate
    {
        // Move
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        // Platform Check
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.2f, rigid.velocity.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0)); // DrawRay : 에디터 상에서만 Ray를 그려주는 함수

        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform")); // Ray에 닿은 오브젝트
                                                                                                                 // GetMask() : 레이어 이름에 해당하는 정수값을 리턴하는 함수
        if (rayHit.collider == null)        
            Turn();
        
    }

    void Think() // 행동지표를 바꿔주는 재귀 함수
    {
        // Set Next Active
        nextMove = Random.Range(-1, 2); // Random : 랜덤 수를 생성하는 로직 관련 클래스
                                        // Range() : 최소 ~ 최대 범위의 랜덤 수 생성 ( 최대 제외 )
     
        // Sprite Animation
        anim.SetInteger("MoveSpeed", nextMove);

        // Flip Sprite
        if (nextMove != 0)
            spriteRenderer.flipX = nextMove == 1;

        // Set Next Active ( Recursive )
        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
    }

    void Turn()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;
        CancelInvoke(); // CancelInvoke() : 현재 작동중인 모든 Invoke함수를 멈추는 함수
        Invoke("Think", 5);
    }
}
