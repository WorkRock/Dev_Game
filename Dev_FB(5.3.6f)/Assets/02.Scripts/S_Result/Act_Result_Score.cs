using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Act_Result_Score : MonoBehaviour {
    int lastScore;

    Text ScoreText;

    // Use this for initialization
    void Start () {
        ScoreText = gameObject.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        lastScore = PlayerPrefs.GetInt("Score");
        ScoreText.text = lastScore.ToString();
    }
}
