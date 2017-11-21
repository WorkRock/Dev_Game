using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act_Score : MonoBehaviour {

    int score = 0;

    float fdt = 0f;

    GUIText text;
   
    void Start()
    {
        text = gameObject.GetComponent<GUIText>();    
    }

    // Update is called once per frame
    void Update () {
        dt_for_score();
	}

    void dt_for_score()
    {
        fdt += Time.deltaTime;
        if(fdt > 0.2f)
        {
            score += 10;
            text.text = score.ToString();
            fdt = 0f;
        }
    }
}
