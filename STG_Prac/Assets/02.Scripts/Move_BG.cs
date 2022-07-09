using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_BG : MonoBehaviour
{
    Renderer m_Renderer;

    public float scrollSpeed;
    public float offSet;

    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offSet += Time.deltaTime * scrollSpeed;
        m_Renderer.material.mainTextureOffset = new Vector2(0, offSet);
    }
}
