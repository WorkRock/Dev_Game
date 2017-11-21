using UnityEngine;
using System.Collections;

public class act_ColTrigger : MonoBehaviour {

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Time.timeScale = 0f;
            Application.LoadLevelAsync(3);
            //Destroy(col.gameObject);
        }
    }
}
