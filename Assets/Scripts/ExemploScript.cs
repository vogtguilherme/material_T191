using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExemploScript : MonoBehaviour
{
    private Renderer m_Renderer;

    private void Awake()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            m_Renderer.material.color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            m_Renderer.material.color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            m_Renderer.material.color = Color.blue;
        }
    }
}
