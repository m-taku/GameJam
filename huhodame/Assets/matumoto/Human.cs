using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] float speed = 20.0f;
    public bool m_evil = false;
    public bool m_sensor = false;
    public GameObject Score;
    ScoreManager m_ScoreManager;
    CharacterController m_CharCon;
    public Sprite p_Sprite;
    public enum MyNo
    {
        dummy_sensor,
        fork,
        fry_kaeshi,
        frying_pan,
        knife,
        nuigurumi,
        pistol
    };
    public MyNo motimono;
    // Start is called before the first frame update
    void Start()
    {
        m_CharCon = this.GetComponent<CharacterController>();
        int m = (int)MyNo.frying_pan;
        motimono = (MyNo)Random.Range(0, m);
        m_ScoreManager = Score.GetComponent<ScoreManager>();
        if (m_evil)
        {
            motimono = MyNo.knife;
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
