﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class act_score : MonoBehaviour {

    public int score = 0;
    public float fdt = -1.8f;

    Text ScoreText;

	void Start () {
        ScoreText = gameObject.GetComponent<Text>();
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    void Update () {
        dt_for_Score();
    }

    void dt_for_Score()
    {
        fdt += Time.deltaTime;
        if (fdt > 4.95f)
        {
            score += 1;
            ScoreText.text = score.ToString();
            fdt = 0f;
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.Save();
        }
    }
}
