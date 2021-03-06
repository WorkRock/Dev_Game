﻿using UnityEngine;
using System.Collections;

public class act_Result : MonoBehaviour {
    public GameObject Bronze;
    public GameObject Silver;
    public GameObject Gold;
    public GameObject Platinum;

	// Use this for initialization
	void Start () {
        Bronze.SetActive(false);
        Silver.SetActive(false);
        Gold.SetActive(false);
        Platinum.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        int lastScore = PlayerPrefs.GetInt("Score");
        lastScore = lastScore / 2;
        if(lastScore >= 10 && lastScore < 20)
        {
            Bronze.SetActive(true);
        }
        else if (lastScore >= 20 && lastScore < 30)
        {
            Silver.SetActive(true);
        }
        else if (lastScore >= 30 && lastScore < 40)
        {
            Gold.SetActive(true);
        }
        else if (lastScore >= 40)
        {
            Platinum.SetActive(true);
        }

    }
}
