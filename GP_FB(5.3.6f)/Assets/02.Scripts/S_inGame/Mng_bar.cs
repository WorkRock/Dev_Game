using UnityEngine;
using System.Collections;

public class Mng_bar : MonoBehaviour {
    float fdt = 3.0f;   
    public float Bar_Cooltime = 3.0f;

    public float barpos;

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
    }
    void Update () {
        fdt += Time.deltaTime;
        barpos = Random.Range(4.0f,7.0f);
        if (fdt > Bar_Cooltime)
        {
            CreateUpBar();
            CreateDownBar();
        }
            
    }

    void CreateUpBar()        // 몬스터생성 함수
    {
        fdt = 0.0f;         // 델타타임 초기화
        Prefabs_bars = Instantiate(bar_up);
        Prefabs_bars.transform.parent = Parents_bars.transform;
        Prefabs_bars.transform.localScale = new Vector3(4, 4, 1);
        Prefabs_bars.transform.localPosition = new Vector3(14.5f, 1.0f + barpos, 0);
    }

    void CreateDownBar()        // 몬스터생성 함수
    {
        fdt = 0.0f;         // 델타타임 초기화
        Prefabs_bars = Instantiate(bar_down);
        Prefabs_bars.transform.parent = Parents_bars.transform;
        Prefabs_bars.transform.localScale = new Vector3(4, 5, 1);
        Prefabs_bars.transform.localPosition = new Vector3(14.5f, -8.0f + barpos, 0);
    }
}
