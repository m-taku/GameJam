using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Human : MonoBehaviour
{
    public float speed = 20.0f;
    bool m_evil = false;
    bool m_ded = true;
    bool m_sensor = true;
    [SerializeField] Material m_Material = null;
    [SerializeField] GameObject m_obj = null;
    CharacterController m_CharCon;
    private Animator animator;
    public Sprite p_Sprite;
    Vector3 m_moveSpeed = Vector3.zero;
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
        animator = GetComponent<Animator>();
        m_CharCon = this.GetComponent<CharacterController>();
        int m = (int)MyNo.frying_pan;
        motimono = (MyNo)Random.Range(0, m);
        if (m_evil)
        {
            motimono = MyNo.knife;
            Debug.Log("nuiaefhw");
        }
        m_moveSpeed = transform.forward;
        m_moveSpeed.y -= 0.5f;
        m_CharCon = this.GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (m_moveSpeed.y >= -10.0f)
        {
            m_moveSpeed.y -= 1.0f;
        }
        if(!m_ded)
        {
            if(m_CharCon.isGrounded)
            {
                speed = 0.0f;
            }
        }
        m_CharCon.Move(m_moveSpeed * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider t)
    {
       
        if (t.gameObject.tag == "end point")
        {
            //ここでスコアを減算する
            ScoreManager.Escape(m_evil);
            Destroy(this.transform.gameObject);
        }
        if (t.gameObject.tag == "Bullet")
        {
            if (m_ded)
            {
                Debug.Log("死ぬーーー");
                ScoreManager.AddScore(m_evil);
                m_moveSpeed = this.transform.position - t.transform.position;
                m_moveSpeed.y += 200.0f;
                m_moveSpeed = m_moveSpeed.normalized;
                m_moveSpeed *= 10.0f;
                animator.SetTrigger("IsDead");
                m_CharCon.Move(m_moveSpeed * speed * Time.deltaTime);
                m_ded = false;
            }
        }
    }
    void daed()
    {
        Destroy(this.transform.gameObject);
    }
}
