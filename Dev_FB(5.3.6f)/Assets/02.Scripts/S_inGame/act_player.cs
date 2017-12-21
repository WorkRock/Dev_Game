using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class act_player : MonoBehaviour {

    public float fGravity = 0.1f;
    public float fImpulse = 4.0f;
    public float fMovePower = 0f;
    public int score;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    void Update () {
        gameObject.transform.localPosition = new Vector3(
            gameObject.transform.localPosition.x,
            gameObject.transform.localPosition.y + fMovePower * Time.deltaTime,
            gameObject.transform.localPosition.z);
        transFormAngle();
        transFormMove();
        if(gameObject.transform.localPosition.y > 5.5f)
        {
            Time.timeScale = 0f;
            Application.LoadLevelAsync(3);
        }
	}

    void transFormAngle()
    {
        gameObject.transform.localEulerAngles = new Vector3(
            gameObject.transform.localEulerAngles.x,
            gameObject.transform.localEulerAngles.y,
            fMovePower * 10);
    }

    void transFormMove()
    {
        fMovePower -= fGravity;
        if (Input.GetKeyDown(KeyCode.Space)) { 
                    fMovePower = fImpulse;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "getScore")
        {
            score = PlayerPrefs.GetInt("Score");
            PlayerPrefs.SetInt("Score", score+1);
            PlayerPrefs.Save();
        }
    }
}
