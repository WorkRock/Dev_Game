using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public float enemySpeed;

    public int enemyScore;
    public int rareEnemy;

    public int[] enemysHP;
    public int enemyHP;
    
    public int ranItem;
    public string[] item;
    public Sprite[] sprites;

    public GameObject player;
    public float fdt;
    public float bulletDelay;
    public float enemyBulletSpeed;

    public objectManager objectManager;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        item = new string[] { "itemCoin, itemPower, itemBoom" };
    }


    private void Start()
    {
        rareEnemy = Random.Range(0, 2);
    }

    void OnEnable()
    {
        switch (enemyName)
        {
            case "S":
                enemyHP = enemysHP[0];
                break;
            case "M":
                enemyHP = enemysHP[1];
                break;
            case "L":
                enemyHP = enemysHP[2];
                break;

        }
    }


    // Update is called once per frame
    void Update()
    {
        fdt += Time.deltaTime;

        fire();
    }

    public void enemyHealth(int dmg)
    {
        if(enemyHP <= 0)
            return;

        enemyHP -= dmg;
        spriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite",0.1f);
        
        if(enemyHP <= 0)
        {
            Player_Move playerLogic = player.GetComponent<Player_Move>();
            playerLogic.score += enemyScore;

            if(rareEnemy == 1)
            {
                ranItem = Random.Range(0, item.Length);

                switch (ranItem)
                {
                    case 0:
                        //Debug.Log("Case 1");
                        GameObject itemCoin = objectManager.MakeObj(item[ranItem]);
                        itemCoin.transform.position = transform.position;                   
                        break;
                    case 1:
                        //Debug.Log("Case 2");
                        GameObject itemPower = objectManager.MakeObj(item[ranItem]);
                        itemPower.transform.position = transform.position;
                        break;
                    case 2:
                        //Debug.Log("Case 3");
                        GameObject itemBoom = objectManager.MakeObj(item[ranItem]);
                        itemBoom.transform.position = transform.position;
                        break;
                }      
            }
            transform.rotation = Quaternion.identity;
            gameObject.SetActive(false);
        }
    }

    public void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    public void fire()
    {
        if (fdt < bulletDelay)
        {
            return;
        }

        
        if (enemyName == "S")
        {
            GameObject bullet = objectManager.MakeObj("bulletEnemy_04");
            bullet.transform.position = transform.position;

            Rigidbody rigid = bullet.GetComponent<Rigidbody>();       
            Vector3 dirVec = player.transform.position - transform.position;
            rigid.velocity = dirVec.normalized * enemyBulletSpeed;
        }
        else if (enemyName == "L")
        {
            GameObject bulletL = objectManager.MakeObj("bulletEnemy_02");
            bulletL.transform.position = transform.position + Vector3.left * 0.3f;

            GameObject bulletR = objectManager.MakeObj("bulletEnemy_02"); 
            bulletR.transform.position = transform.position + Vector3.right * 0.3f;

            Rigidbody rigidL = bulletL.GetComponent<Rigidbody>();
            Rigidbody rigidR = bulletR.GetComponent<Rigidbody>();

            Vector3 dirVecL = player.transform.position - (transform.position + Vector3.left * 0.3f);
            Vector3 dirVecR = player.transform.position - (transform.position + Vector3.right * 0.3f);

            rigidL.velocity = dirVecL.normalized * enemyBulletSpeed;
            rigidR.velocity = dirVecR.normalized * enemyBulletSpeed;
        }
        fdt = 0.0f;
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Destroy")
        {
            gameObject.SetActive(false);
            transform.rotation = Quaternion.identity;
        }

        else if(other.gameObject.tag == "Bullet")
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();
            enemyHealth(bullet.dmg);

            other.gameObject.SetActive(false);
        }
    }
}
