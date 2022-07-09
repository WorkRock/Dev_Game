using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string type;
    public float itemSpeed;
    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();    
    }

    void OnEnable()
    {
        rigid.velocity = Vector3.down * itemSpeed;
    }
}
