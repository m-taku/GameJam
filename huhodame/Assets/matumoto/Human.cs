using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Human : MonoBehaviour
{
    [SerializeField] float speed = 20.0f;
    bool m_evil = false;
    bool m_sensor = false;
    [SerializeField] Material m_Material;
    [SerializeField] GameObject m_obj;
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
    public Material getmaterial()
    {
        return m_Material;
    }
    public GameObject getobj()
    {
        return m_obj;
    }
    public bool getevil()
    {
        return m_evil;
    }
    public void setevil(bool frag)
    {
        m_evil = frag;
    }
    public bool getsensor()
    {
        return m_sensor;
    }
    public void setsensor(bool frag)
    {
        m_sensor = frag;
    }
    public MyNo motimono;
    // Start is called before the first frame update
    void Start()
    {
        m_CharCon = this.GetComponent<CharacterController>();
        int m = (int)MyNo.frying_pan;
        motimono = (MyNo)Random.Range(0, m);
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
        var moveSpeed = transform.forward;
        moveSpeed.y -= 0.5f;
        m_CharCon.Move(moveSpeed * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider t)
    {
       
        if (t.gameObject.tag == "end point")
        {
            //ここでスコアを減算する
            ScoreManager.Escape(m_evil);
            Destroy(this.transform.gameObject);   
        }
        if(t.gameObject.tag == "Bullet")
        {
            ScoreManager.AddScore(m_evil);
            Destroy(this.transform.gameObject);
        }
    }
}
