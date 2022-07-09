using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public int dmg;

    public bool isRotate;

    // Update is called once per frame
    void Update()
    {
        if(isRotate)
        {
            transform.Rotate(Vector3.forward * 10);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Destroy")
        {
            gameObject.SetActive(false);
        }
    }
}
