using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class act_background : MonoBehaviour
{
    public float Background_Speed = 1.0f;       

    void Update()
    {
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x - Background_Speed * Time.deltaTime,
        gameObject.transform.localPosition.y,
        gameObject.transform.localPosition.z);

        if (gameObject.transform.localPosition.x < -3.3f)
            gameObject.transform.localPosition = new Vector3(20.0f,
            gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
    }
}
