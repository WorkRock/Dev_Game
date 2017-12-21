using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class act_score : MonoBehaviour {

    public int score = 0;
    // public float fdt = -1.8f;

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
        score = PlayerPrefs.GetInt("Score");
        score = score / 2;
        ScoreText.text = score.ToString();
    }
}
