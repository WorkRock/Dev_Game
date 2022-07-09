using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    Animator animator;

    public int life;
    public int score;

    public float Speed;

    private float fHor;
    private float fVer;

    public Vector2 limitMin;
    public Vector2 limitMax;

    public gameManager gameManager;
    public objectManager objectManager;
    
    public bool isHit;

    public int maxPow;
    public int pow;
    public int boomCnt;
    public int maxBoom;
    public GameObject boomEffect;

    public float fdt;
    public float bulletDelay;
    public float bulletSpeed;



    public bool isBoomTime;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        fdt += Time.deltaTime;
        PlayerMove();

        fire();
        boom();
    }

    public void PlayerMove()
    {
        fHor = Input.GetAxisRaw("Horizontal");
        fVer = Input.GetAxisRaw("Vertical");

        animator.SetInteger("Input", (int)fHor);

        if(transform.position.x < limitMin.x && fHor < 0.0f || (transform.position.x > limitMax.x && fHor > 0.0f))
        {
            fHor = 0;
        }

        if (transform.position.y < limitMin.y && fVer < 0.0f || (transform.position.y > limitMax.y && fVer > 0.0f))
        {
            fVer = 0;
        }

        transform.Translate(fHor * Time.deltaTime * Speed, fVer * Time.deltaTime * Speed, 0);
    }

    public void fire()
    {
        if (fdt < bulletDelay)        
            return;

        if (!Input.GetKey(KeyCode.Z))
            return;

        switch (pow)
        {
            case 0:
                GameObject bullet = objectManager.MakeObj("bulletPlayer_Nor");
                bullet.transform.position = transform.position;

                Rigidbody rigid = bullet.GetComponent<Rigidbody>();
                rigid.velocity = Vector3.up * bulletSpeed;
                break;
            case 1:
                GameObject bulletL = objectManager.MakeObj("bulletPlayer_Nor");
                bulletL.transform.position = transform.position - Vector3.left * (0.1f);

                GameObject bulletR = objectManager.MakeObj("bulletPlayer_Nor");
                bulletR.transform.position = transform.position - Vector3.right * (0.1f);

                Rigidbody rigidL = bulletL.GetComponent<Rigidbody>();
                Rigidbody rigidR = bulletR.GetComponent<Rigidbody>();
                rigidL.velocity = Vector3.up * bulletSpeed;
                rigidR.velocity = Vector3.up * bulletSpeed;
                break;
            case 2:
                GameObject bulletLL = objectManager.MakeObj("bulletPlayer_Nor");
                bulletLL.transform.position = transform.position - Vector3.left * (0.2f);

                GameObject bulletMM = objectManager.MakeObj("bulletPlayer_Pow");
                bulletMM.transform.position = transform.position + Vector3.up * (0.2f);

                GameObject bulletRR = objectManager.MakeObj("bulletPlayer_Nor");
                bulletRR.transform.position = transform.position - Vector3.right * (0.2f);

                Rigidbody rigidLL = bulletLL.GetComponent<Rigidbody>();
                Rigidbody rigidMM = bulletMM.GetComponent<Rigidbody>();
                Rigidbody rigidRR = bulletRR.GetComponent<Rigidbody>();
                rigidLL.velocity = Vector3.up * bulletSpeed;
                rigidMM.velocity = Vector3.up * bulletSpeed;
                rigidRR.velocity = Vector3.up * bulletSpeed;
                break;
        }

        fdt = 0.0f;
    }

    public void boom()
    {
        gameManager.UpdateBoomIcon(boomCnt);

        if (!Input.GetKey(KeyCode.X))
            return;

        if (isBoomTime)
            return;

        if (boomCnt == 0)
            return;

        boomCnt--;
        
        isBoomTime = true;

        boomEffect.SetActive(true);
        Invoke("OffBoomEffect", 4f);

        List<GameObject> enemiesA = objectManager.GetPool("enemyA");
        List<GameObject> enemiesB = objectManager.GetPool("enemyB");
        List<GameObject> enemiesC = objectManager.GetPool("enemyC");

        for(int index = 0; index < enemiesA.Count; index++)
        {
            if (enemiesA[index].activeSelf)
            {
                Enemy enemyLogic = enemiesA[index].GetComponent<Enemy>();
                enemyLogic.enemyHealth(1000);
            }
        }

        for (int index = 0; index < enemiesB.Count; index++)
        {
            if (enemiesB[index].activeSelf)
            {
                Enemy enemyLogic = enemiesB[index].GetComponent<Enemy>();
                enemyLogic.enemyHealth(1000);
            }
        }

        for (int index = 0; index < enemiesC.Count; index++)
        {
            if (enemiesC[index].activeSelf)
            {
                Enemy enemyLogic = enemiesC[index].GetComponent<Enemy>();
                enemyLogic.enemyHealth(1000);
            }
        }

        List<GameObject> bullets01 = objectManager.GetPool("bulletEnemy_01");
        List<GameObject> bullets02 = objectManager.GetPool("bulletEnemy_02");
        List<GameObject> bullets03 = objectManager.GetPool("bulletEnemy_03");
        List<GameObject> bullets04 = objectManager.GetPool("bulletEnemy_04");

        for (int index = 0; index < bullets01.Count; index++)
        {
            if (bullets01[index].activeSelf)
            {
                bullets01[index].SetActive(false);
            }
        }

        for (int index = 0; index < bullets02.Count; index++)
        {
            if (bullets02[index].activeSelf)
            {
                bullets02[index].SetActive(false);
            }
        }

        for (int index = 0; index < bullets03.Count; index++)
        {
            if (bullets03[index].activeSelf)
            {
                bullets03[index].SetActive(false);
            }
        }

        for (int index = 0; index < bullets04.Count; index++)
        {
            if (bullets04[index].activeSelf)
            {
                bullets04[index].SetActive(false);
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet_Enemy" || other.gameObject.tag == "Enemy")
        {
            if (isHit)
                return;

            isHit = true;
            life--;
            gameManager.UpdateLifeIcon(life);

            if(life == 0)
            {
                gameManager.GameOver();
            }
            else
            {
                gameManager.RespawnPlayer();
            }
            
            other.transform.rotation = Quaternion.identity;

            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }



        else if (other.gameObject.tag == "Item")
        {
            Item item = other.gameObject.GetComponent<Item>();
            switch (item.type)
            {
                case "Coin":
                    score += 1000;
                    break;
                case "Power":
                    if (pow == maxPow)
                    {
                        score += 500;
                    }
                    else
                        pow++;
                    
                    break;
                case "Boom":
                    if (boomCnt == maxBoom)
                    {
                        score += 500;
                    }
                    else
                        boomCnt++;

                    break;
            }
            other.gameObject.SetActive(false);
        }
    }

    void OffBoomEffect()
    {
        boomEffect.SetActive(false);
        isBoomTime = false;
    }
}
