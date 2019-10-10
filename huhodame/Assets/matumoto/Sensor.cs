using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor : MonoBehaviour
{
    [SerializeField] GameObject[] m_Imageobj = new GameObject[2];
    [SerializeField] KeyCode m_key;
    Image[] m_Image = new Image[2];
    GameObject m_Human;
    Human m_human = null;
    public Sprite[] sprite;
    private void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            m_Image[i] = m_Imageobj[i].GetComponent<Image>();
        }
    }
    void OnTriggerEnter(Collider t)
    {

        if (t.gameObject.tag == "Player")
        {
            m_human = t.gameObject.GetComponent<Human>();
            m_Human = m_human.getobj();
            if (m_human.getsensor() ==false)
            {
                Debug.Log("発見！！！");

                m_Image[0].sprite = sprite[(int)m_human.motimono];
                m_Image[1].sprite = m_human.p_Sprite;
                m_human.setsensor(true);
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
            if (m_human != null)
            {
                m_Human.GetComponent<Renderer>().material = m_human.getmaterial();
            }
        }
        //Press space to change the Sprite of the Image
    }



}
