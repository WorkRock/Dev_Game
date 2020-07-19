using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    CapsuleCollider2D capsuleCollider;

    public GameManager gameManager;
    public float maxSpeed;
    public float jumpPower;
    public bool isDIe = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();

    }

    void Update() // 단발적인 키 입력은 Update를 사용하자
    {
        // Jump
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping"))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0); // 점프높이초기화로 피격후 슈퍼점프 방지
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }

        // Stop Speed
        if (Input.GetButtonUp("Horizontal"))
        {
             // normalized : 벡터크기를 1로 만든 상태 주로 방향을 구할때 사용함
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        // Direction Sprite
        if (Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        // Animation
        // Mathf : 유니티에서 제공하는 수학 함수들(abs = 절대값)
        if(Mathf.Abs(rigid.velocity.x) < 0.3)
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
        }

    }

    void FixedUpdate()
    {
        // Move By Key Control
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        // Max Speed
        if (rigid.velocity.x > maxSpeed) // Right Max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed*(-1)) // Left Max Speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        // Landing Platform
        // RayCast : 오브젝트 검색을 위해 Ray를 쏘는 방식
        if(rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0)); // DrawRay : 에디터 상에서만 Ray를 그려주는 함수

            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform")); // Ray에 닿은 오브젝트
                                                                                                                     // GetMask() : 레이어 이름에 해당하는 정수값을 리턴하는 함수
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                    anim.SetBool("isJumping", false);
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            // Attack
            if (rigid.velocity.y < 0 && transform.position.y > collision.transform.position.y)
            {
                OnAttack(collision.transform);
            }
            else // Debug.Log("플레이어가 히트당함");
                OnDamaged(collision.transform.position);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            // Point
            bool isBCoin = collision.gameObject.name.Contains("BCoin");
            bool isSCoin = collision.gameObject.name.Contains("SCoin");
            bool isGCoin = collision.gameObject.name.Contains("GCoin");
            
            if(isBCoin)
                gameManager.stagePoint += 50;
            else if(isSCoin)
                gameManager.stagePoint += 100;
            else if(isGCoin)
                gameManager.stagePoint += 300;

            // Deactive Item
            collision.gameObject.SetActive(false);
        }
        else if(collision.gameObject.tag == "Finish")
        {
            // Next Stage
            gameManager.NextStage();
        }
    }

    void OnAttack(Transform enemy)
    {
        // Point
        gameManager.stagePoint += 100;

        // EnemyDie
        Monster_Move monsterMove = enemy.GetComponent<Monster_Move>();
        monsterMove.OnDamaged();
    }
    
    void OnDamaged(Vector2 targetPos)
    {
        // Health Down
        gameManager.HealthDown();
        
        // Change Layer (Immortal Active)
        gameObject.layer = 11; // 레이어를 바꾸어 피격 안당하게 조정

        // View Alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f); // 살짝 투명하게 변경

        // Reaction Force
        int direcion = transform.position.x - targetPos.x > 0 ? 1 : -1; // 방향 설정
        rigid.AddForce(new Vector2(direcion, 1)*7, ForceMode2D.Impulse); // 살짝 튀어오름

        // Animation
        anim.SetTrigger("isDamaged"); // 트리거를 실행시켜 피격 애니메이션 실행

        Invoke("OffDamaged", 2); // 2초후 다시 원상복귀 하도록 조정
    }

    public void OffDamaged() 
    {
        gameObject.layer = 10; // 레이어를 기존 플레이어 레이어로 변경해서 원상 복귀
        spriteRenderer.color = new Color(1, 1, 1, 1); // 투명도 다시 원상복귀
    }

    public void OnDie()
    {
        // Sprite Alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        // Sprite Flip Y
        spriteRenderer.flipY = true;

        // Colider Disable
        capsuleCollider.enabled = false;

        // Die Effect Jump
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    }
}
