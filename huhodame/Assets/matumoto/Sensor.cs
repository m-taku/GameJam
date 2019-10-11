using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor : MonoBehaviour
{
    [SerializeField] GameObject[] m_Imageobj = new GameObject[3];
    [SerializeField] KeyCode m_key;
    Image[] m_Image = new Image[3];
    GameObject m_Human;
    Human m_human = null;
    public Sprite[] sprite;
    private GameObject A_Check = null;
    private GameObject B_Check = null;
    public Sprite NoCheckSprite;
    public Sprite CheckSprite;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            m_Image[i] = m_Imageobj[i].GetComponent<Image>();
        }
    }
    void OnTriggerEnter(Collider t)
    {

        if (t.gameObject.tag == "Player")
        {
            var n = t.gameObject.GetComponent<Human>();
            if (n.getsensor())
            {
                Debug.Log("発見！！！");
                m_human = n;
                m_Human = m_human.getobj();
                m_Image[0].sprite = sprite[(int)m_human.motimono];
                m_Image[1].sprite = m_human.p_Sprite;
                m_Image[2].sprite = NoCheckSprite;
                m_human.setsensor(false);
            }
        }
    }



    //{
    // Image m_Image;
    ////Set this in the Inspector
    //public Sprite m_Sprite;

    //void Start()
    //{
    //    //Fetch the Image from the GameObject
    //    m_Image = GetComponent<Image>();
    //}

    void Update()
    {
        if (Input.GetKey(m_key)){
            if (m_Human != null)
            {
                m_Human.GetComponent<Renderer>().material = m_human.getmaterial();
                m_Human = null;
                m_Image[2].sprite = CheckSprite;
            }
        }
        //Press space to change the Sprite of the Image
    }

    public KeyCode GetKeyCode()
    {
        return m_key;
    }
    public void SetKeyCode(KeyCode key)
    {
        m_key = key;
    }
}
