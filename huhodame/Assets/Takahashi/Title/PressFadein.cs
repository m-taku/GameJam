using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressFadein : MonoBehaviour
{
    public float timeOut; //時間のボーダー
    private float timeElapsed;
    int Timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        Vector4 sp_color = this.GetComponent<Image>().color;
        sp_color.w = 0.0f;
        this.GetComponent<Image>().color = sp_color;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut)
        {
            // Do anything
            Timer++;

            if (Timer > 180)
            {
                //不透明度！
                Vector4 sp_color = this.GetComponent<Image>().color;
                sp_color.w += 0.05f;
                Mathf.Max(sp_color.w, 1.0f);
                this.GetComponent<Image>().color = sp_color;
            }

            timeElapsed = 0.0f;
        }

    }
}
