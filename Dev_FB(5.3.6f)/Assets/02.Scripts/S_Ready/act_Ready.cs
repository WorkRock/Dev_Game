using UnityEngine;
using System.Collections;

public class act_Ready : MonoBehaviour {
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Application.LoadLevelAsync(2);
    }
}
