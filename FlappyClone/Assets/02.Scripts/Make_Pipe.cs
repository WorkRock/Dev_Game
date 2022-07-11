using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make_Pipe : MonoBehaviour
{
    public GameObject pipe;
    public float timeDiff;
    public float randomMin;
    public float randomMax;
    public float destTime;

    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeDiff)
        {
            GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = new Vector3(6, Random.Range(randomMin, randomMax), 0);
            timer = 0;
            Destroy(newPipe, destTime);
        }
    }
}
