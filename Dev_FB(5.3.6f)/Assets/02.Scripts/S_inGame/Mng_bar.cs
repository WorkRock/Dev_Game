using UnityEngine;
using System.Collections;

public class Mng_bar : MonoBehaviour {
    float fdt = 3.0f;   
    public float Bar_Cooltime = 3.0f;

    public float barpos;

    public GameObject getScore;
    public GameObject bar_up;
    public GameObject bar_down;
    public GameObject Parents_bars;
    GameObject Prefabs_bars;

   void Start()
    {
        Prefabs_bars = Instantiate(bar_up);
        Prefabs_bars.transform.parent = Parents_bars.transform;
        Prefabs_bars.transform.localScale = new Vector3(4, 4, 1);
        Prefabs_bars.transform.localPosition = new Vector3(11.5f, 6.0f, 0);

        Prefabs_bars = Instantiate(bar_down);
        Prefabs_bars.transform.parent = Parents_bars.transform;
        Prefabs_bars.transform.localScale = new Vector3(4, 5, 1);
        Prefabs_bars.transform.localPosition = new Vector3(11.5f, -3.0f, 0);

        Prefabs_bars = Instantiate(getScore);
        Prefabs_bars.transform.parent = Parents_bars.transform;
        Prefabs_bars.transform.localScale = new Vector3(4, 5, 1);
        Prefabs_bars.transform.localPosition = new Vector3(13.5f, 3.0f, 0);
    }
    void Update () {
        fdt += Time.deltaTime;
        barpos = Random.Range(4.0f,7.0f);

        if (fdt > Bar_Cooltime)
        {
            CreateUpBar();
            CreateDownBar();
            CreateGetScore();
        }
            
    }

    void CreateUpBar()
    {
        fdt = 0.0f;
        Prefabs_bars = Instantiate(bar_up);
        Prefabs_bars.transform.parent = Parents_bars.transform;
        Prefabs_bars.transform.localScale = new Vector3(4, 4, 1);
        Prefabs_bars.transform.localPosition = new Vector3(14.5f, 1.0f + barpos, 0);
    }

    void CreateDownBar()
    {
        Prefabs_bars = Instantiate(bar_down);
        Prefabs_bars.transform.parent = Parents_bars.transform;
        Prefabs_bars.transform.localScale = new Vector3(4, 5, 1);
        Prefabs_bars.transform.localPosition = new Vector3(14.5f, -8.0f + barpos, 0);
    }

    void CreateGetScore()
    {
        Prefabs_bars = Instantiate(getScore);
        Prefabs_bars.transform.parent = Parents_bars.transform;
        Prefabs_bars.transform.localScale = new Vector3(4, 8, 1);
        Prefabs_bars.transform.localPosition = new Vector3(16.5f,3.0f, 0);
    }
}
