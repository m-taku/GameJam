using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor : MonoBehaviour
{
    [SerializeField] GameObject[] m_Imageobj = new GameObject[2];
    Image[] m_Image = new Image[2];
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
            var na = t.gameObject.GetComponent<Human>();
            if (na.m_sensor ==false)
            {
                Debug.Log("発見！！！");

                m_Image[0].sprite = sprite[(int)na.motimono];
                m_Image[1].sprite = na.p_Sprite;
                na.m_sensor = true;
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

    //void Update()
    //{
    //    //Press space to change the Sprite of the Image
    //    if (Input.GetKey(KeyCode.Space))
    //    {
    //        m_Image.sprite = m_Sprite;
    //    }
    //}



}
