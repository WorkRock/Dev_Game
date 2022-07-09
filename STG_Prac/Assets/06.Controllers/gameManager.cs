using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = FindObjectOfType<gameManager>();
            }

            return m_instance;
        }
    }

    private static gameManager m_instance;


    public Transform[] spawnPoint;
    public string[] EnemyObj;
    public GameObject player;

    public Text scoreText;
    public Image[] lifeImage;
    public Image[] boomImage;
    public GameObject gameOverSet;
    public objectManager objectManager;

    public float curSpawnDelay;
    public float maxSpawnDelay;

    public float ranMin;
    public float ranMax;

    public int ranSpwn;
    public int ranEnm;

    void Awake()
    {
        EnemyObj = new string[]{ "enemyA", "enemyB", "enemyC" };
    }


    private void Start()
    {
        curSpawnDelay = 0;
    }

    private void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay)
        {
            spawnEnemy();
            maxSpawnDelay = Random.Range(ranMin, ranMax);
            curSpawnDelay = 0;
        }

        Player_Move playerLogic = player.GetComponent<Player_Move>();
        scoreText.text = string.Format("{0:n0}", playerLogic.score);

    }

    public void spawnEnemy()
    {
        
        ranSpwn = Random.Range(0, spawnPoint.Length);
        ranEnm = Random.Range(0, EnemyObj.Length);
        
        GameObject enemy = objectManager.MakeObj(EnemyObj[ranEnm]);
        enemy.transform.position = spawnPoint[ranSpwn].position;

        Rigidbody rigid = enemy.GetComponent<Rigidbody>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
        enemyLogic.objectManager = objectManager;

        if(ranSpwn == 5 || ranSpwn == 6)
        {
            enemy.transform.Rotate(Vector3.forward * 90);
            rigid.velocity = new Vector3(enemyLogic.enemySpeed, -1, 0);
        }

        else if (ranSpwn == 7 || ranSpwn == 8)
        {
            enemy.transform.Rotate(Vector3.back * 90);
            rigid.velocity = new Vector3(enemyLogic.enemySpeed * (-1), -1, 0);
        }
        else
        {
            rigid.velocity = new Vector3(0, enemyLogic.enemySpeed * (-1), 0);
        }

        // Debug.Log("Enemy " + ranEnm);
    }

    public void UpdateLifeIcon(int life)
    {
        for (int index = 0; index < 3; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 0);
        }

        for (int index = 0; index < life; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 1);
        }
    }

    public void UpdateBoomIcon(int boomCnt)
    {
        for (int index = 0; index < 3; index++)
        {
            boomImage[index].color = new Color(1, 1, 1, 0);
        }

        for (int index = 0; index < boomCnt; index++)
        {
            boomImage[index].color = new Color(1, 1, 1, 1);
        }
    }


    public void GameOver()
    {
        gameOverSet.SetActive(true);
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }


    public void RespawnPlayer()
    {
        Invoke("RespawnPlayerExe", 2.0f);
    }
    void RespawnPlayerExe()
    {
        player.transform.position = Vector3.down * 2.9f;
        player.SetActive(true);
        Player_Move playerLogic = player.GetComponent<Player_Move>();
        playerLogic.isHit = false;
    }
}
