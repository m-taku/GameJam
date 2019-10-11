using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleWait : MonoBehaviour
{
    public float timeOut; //時間のボーダー
    private float timeElapsed;
    [SerializeField] GameObject Gamemanager;
    GameObject Logo = null;
    int Timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Logo = GameObject.Find("Logo");
        Vector4 col = Logo.GetComponent<Image>().color;
        col.w = 0.0f;
        Logo.GetComponent<Image>().color = col;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut)
        {
            // Do anything
            if(Timer > 30 && Timer < 60)
            {
                Vector4 col = Logo.GetComponent<Image>().color;
                col.w += 0.05f;
                if (col.w > 1.0f)
                {
                    col.w = 1.0f;
                }
                Logo.GetComponent<Image>().color = col;

            }
            else if(Timer>150 && Timer < 180)
            {
                Vector4 col = Logo.GetComponent<Image>().color;
                col.w -= 0.05f;
                if (col.w < 0.0f)
                {
                    col.w = 0.0f;
                }
                Logo.GetComponent<Image>().color = col;

            }
           else if(Timer>=180)
            {
                Gamemanager.GetComponent<GAme>().furag = true;
            }
            Timer++;

            timeElapsed = 0.0f;
        }

    }
}
