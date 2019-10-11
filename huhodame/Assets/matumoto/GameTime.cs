using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    public float m_GameTime = 0.0f;
    [SerializeField] GameObject Gamemanager;
    GAme Gamema;
    public enum day
    {
        Morning,
        Noon,
        Night
    }
    public day m_Day;
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.reset();
        m_GameTime = 0.0f;
        Gamema = Gamemanager.GetComponent<GAme>();
    }

    // Update is called once per frame
    void Update()
    {
        m_GameTime += Time.deltaTime;
        if ((m_GameTime/30)- (int)m_Day >=1)
        {
            if (m_Day != day.Night)
            {
                m_Day++;
            }
            else
            {
                Gamema.furag = true;
            }
        }
        Debug.Log(m_Day);
    }
}
