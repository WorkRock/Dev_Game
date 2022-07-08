using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Move : MonoBehaviour
{
    public float speed;
    public Vector3 limit;
    public Vector3 spawn;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < limit.y)
        {
            transform.position = new Vector3(spawn.x, spawn.y, spawn.z);
        }
        
        transform.Translate(0, (-1) * speed * Time.deltaTime, 0);
    }
}
