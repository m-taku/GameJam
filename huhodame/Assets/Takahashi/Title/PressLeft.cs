using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressLeft : MonoBehaviour
{
    public float timeOut; //時間のボーダー
    private float timeElapsed;
    public Sprite NoPushSprite;
    public Sprite PushSprite;

    //切り替わり～
    int PL_Timer = 0;
    bool PL_MoveFlag = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut)
        {
            // Do anything
            PL_Timer++;

            if (PL_Timer > 60)
            {
                PL_Timer = 0;

                if (PL_MoveFlag == false)
                {
                    this.gameObject.GetComponent<Image>().sprite = PushSprite;
                    PL_MoveFlag = true;
                }
                else
                {
                    this.gameObject.GetComponent<Image>().sprite = NoPushSprite;
                    PL_MoveFlag = false;
                }

            }
            timeElapsed = 0.0f;
        }

    }
}
