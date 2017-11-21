using UnityEngine;
using System.Collections;

public class act_bar : MonoBehaviour {
    public float Bar_Speed = 1.0f;
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x - Bar_Speed * Time.deltaTime,
        gameObject.transform.localPosition.y,
        gameObject.transform.localPosition.z);

        if (gameObject.transform.localPosition.x < -1.5f)
            Destroy(gameObject);
    }
}
