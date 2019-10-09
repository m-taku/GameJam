using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] float speed = 20.0f;
    public bool m_evil = false;
    public GameObject Score;
    ScoreManager m_ScoreManager;
    CharacterController m_CharCon;
    enum MyNo
    {
        nasi,
        knife,
        fakeknife,
        gun,
        gunfake,
    };
    [SerializeField] MyNo naaaa;
    // Start is called before the first frame update
    void Start()
    {
        m_CharCon = this.GetComponent<CharacterController>();
        m_ScoreManager = Score.GetComponent<ScoreManager>();
        if (m_evil)
        {
            Debug.Log("nuiaefhw");
        }
        m_CharCon = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        m_CharCon.Move(transform.forward * speed * Time.deltaTime);
        //transform.position += transform.forward * speed * Time.deltaTime;
    }
    void OnTriggerEnter(Collider t)
    {
       
        if (t.gameObject.tag == "end point")
        {
            //ここでスコアを減算する
            m_ScoreManager.Escape(m_evil);
            Destroy(this.transform.gameObject);   
        }
        if(t.gameObject.tag == "Bullet")
        {
            Debug.Log("aaaaaa");
            Destroy(this.transform.gameObject);
        }
    }
}
