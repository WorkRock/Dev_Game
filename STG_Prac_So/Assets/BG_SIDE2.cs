using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_SIDE2 : MonoBehaviour
{
    public float speed;
    public Vector3 limit;
    public Vector3 spawn;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > limit.x)
        {
            transform.position = new Vector3(spawn.x, spawn.y, spawn.z);
        }

        transform.Translate((-1)*speed * Time.deltaTime, 0, 0);
    }
}
