using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    public float m_GameTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        m_GameTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        m_GameTime += Time.deltaTime;
    }
}
