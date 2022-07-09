using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectManager : MonoBehaviour
{
    public int amountToPool;

    List<GameObject> targetPool;

    public GameObject enemyBossPrefab;
    public GameObject enemyAPrefab;
    public GameObject enemyBPrefab;
    public GameObject enemyCPrefab;

    public GameObject itemCoinPrefab;
    public GameObject itemPowerPrefab;
    public GameObject itemBoomPrefab;

    public GameObject bulletPlayer_NorPrefab;
    public GameObject bulletPlayer_PowPrefab;
    public GameObject bulletEnemy_01Prefab;
    public GameObject bulletEnemy_02Prefab;
    public GameObject bulletEnemy_03Prefab;
    public GameObject bulletEnemy_04Prefab;

    List<GameObject> enemyBoss;
    List<GameObject> enemyA;
    List<GameObject> enemyB;
    List<GameObject> enemyC;

    List<GameObject> itemCoin;
    List<GameObject> itemPower;
    List<GameObject> itemBoom;

    List<GameObject> bulletPlayer_Nor;
    List<GameObject> bulletPlayer_Pow;
    List<GameObject> bulletEnemy_01;
    List<GameObject> bulletEnemy_02;
    List<GameObject> bulletEnemy_03;
    List<GameObject> bulletEnemy_04;

    void Awake()
    {
        enemyBoss = new List<GameObject>();
        enemyA = new List<GameObject>();
        enemyB = new List<GameObject>();
        enemyC = new List<GameObject>();

        itemCoin = new List<GameObject>();
        itemPower = new List<GameObject>();
        itemBoom = new List<GameObject>();

        bulletPlayer_Nor = new List<GameObject>();
        bulletPlayer_Pow = new List<GameObject>();
        bulletEnemy_01 = new List<GameObject>();
        bulletEnemy_02 = new List<GameObject>();
        bulletEnemy_03 = new List<GameObject>();
        bulletEnemy_04 = new List<GameObject>();

        Generate();
    }

    void Generate()
    {
        for (int index = 0; index < amountToPool; index++)
        {
            GameObject enemyBossObj = Instantiate(enemyBossPrefab);
            GameObject enemyAObj = Instantiate(enemyAPrefab);
            GameObject enemyBObj = Instantiate(enemyBPrefab);
            GameObject enemyCObj = Instantiate(enemyCPrefab);

            GameObject itemCoinObj = Instantiate(itemCoinPrefab);
            GameObject itemPowerObj = Instantiate(itemPowerPrefab);
            GameObject itemBoomObj = Instantiate(itemBoomPrefab);

            GameObject bulletPlayer_NorObj = Instantiate(bulletPlayer_NorPrefab);
            GameObject bulletPlayer_PowObj = Instantiate(bulletPlayer_PowPrefab);
            GameObject bulletEnemy_01Obj = Instantiate(bulletEnemy_01Prefab);
            GameObject bulletEnemy_02Obj = Instantiate(bulletEnemy_02Prefab);
            GameObject bulletEnemy_03Obj = Instantiate(bulletEnemy_03Prefab);
            GameObject bulletEnemy_04Obj = Instantiate(bulletEnemy_04Prefab);

            enemyBoss.Add(enemyBossObj);
            enemyA.Add(enemyAObj);
            enemyB.Add(enemyBObj);
            enemyC.Add(enemyCObj);

            itemCoin.Add(itemCoinObj);
            itemPower.Add(itemPowerObj);
            itemBoom.Add(itemBoomObj);

            bulletPlayer_Nor.Add(bulletPlayer_NorObj);
            bulletPlayer_Pow.Add(bulletPlayer_PowObj);
            bulletEnemy_01.Add(bulletEnemy_01Obj);
            bulletEnemy_02.Add(bulletEnemy_02Obj);
            bulletEnemy_03.Add(bulletEnemy_03Obj);
            bulletEnemy_04.Add(bulletEnemy_04Obj);

            enemyBoss[index].SetActive(false);
            enemyA[index].SetActive(false);
            enemyB[index].SetActive(false);
            enemyC[index].SetActive(false);
            itemCoin[index].SetActive(false);
            itemPower[index].SetActive(false);
            itemBoom[index].SetActive(false);
            bulletPlayer_Nor[index].SetActive(false);
            bulletPlayer_Pow[index].SetActive(false);
            bulletEnemy_01[index].SetActive(false);
            bulletEnemy_02[index].SetActive(false);
            bulletEnemy_03[index].SetActive(false);
            bulletEnemy_04[index].SetActive(false);
        }

    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "enemyBoss":
                targetPool = enemyBoss;
                break;
            case "enemyA":
                targetPool = enemyA;
                break;
            case "enemyB":
                targetPool = enemyB;
                break;
            case "enemyC":
                targetPool = enemyC;
                break;

            case "itemCoin":
                targetPool = itemCoin;
                break;
            case "itemPower":
                targetPool = itemPower;
                break;
            case "itemBoom":
                targetPool = itemBoom;
                break;

            case "bulletPlayer_Nor":
                targetPool = bulletPlayer_Nor;
                break;
            case "bulletPlayer_Pow":
                targetPool = bulletPlayer_Pow;
                break;
            case "bulletEnemy_01":
                targetPool = bulletEnemy_01;
                break;
            case "bulletEnemy_02":
                targetPool = bulletEnemy_02;
                break;
            case "bulletEnemy_03":
                targetPool = bulletEnemy_03;
                break;
            case "bulletEnemy_04":
                targetPool = bulletEnemy_04;
                break;
        }

        for (int index = 0; index < amountToPool; index++)
        {
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }

        return null;
    }

    public List<GameObject> GetPool(string type)
    {
        switch (type)
        {
            case "enemyBoss":
                targetPool = enemyBoss;
                break;
            case "enemyA":
                targetPool = enemyA;
                break;
            case "enemyB":
                targetPool = enemyB;
                break;
            case "enemyC":
                targetPool = enemyC;
                break;

            case "itemCoin":
                targetPool = itemCoin;
                break;
            case "itemPower":
                targetPool = itemPower;
                break;
            case "itemBoom":
                targetPool = itemBoom;
                break;

            case "bulletPlayer_Nor":
                targetPool = bulletPlayer_Nor;
                break;
            case "bulletPlayer_Pow":
                targetPool = bulletPlayer_Pow;
                break;
            case "bulletEnemy_01":
                targetPool = bulletEnemy_01;
                break;
            case "bulletEnemy_02":
                targetPool = bulletEnemy_02;
                break;
            case "bulletEnemy_03":
                targetPool = bulletEnemy_03;
                break;
            case "bulletEnemy_04":
                targetPool = bulletEnemy_04;
                break;
        }

        return targetPool;
    }
}

