using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 時間に応じて時計を動かします
/// </summary>
public class Timer_Move : MonoBehaviour
{
    public float timeOut; //時間のボーダー
    private float timeElapsed;

    GameObject GameObj = null;

    //演出フラグ
    int m_noonTimer = 0;
    int m_nightTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObj = GameObject.Find("GameObject");
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut)
        {
            // Do anything
            TimeMove();

            timeElapsed = 0.0f;
        }

    }

    /// <summary>
    /// 時間遷移演出
    /// </summary>
    void TimeMove()
    {
        GameTime.day NowTime = GameObj.GetComponent<GameTime>().m_Day;

        switch(NowTime)
        {
            case GameTime.day.Noon: //お昼よ～

                if (m_noonTimer <= 20)
                {
                    this.transform.Rotate(new Vector3(0, 0, 70.0f / 20.0f));
                }
                else if (m_noonTimer <= 30)
                {
                    this.transform.Rotate(new Vector3(0, 0, -10.0f / 20.0f));
                }

                m_noonTimer++;
                break;

            case GameTime.day.Night: //よる！！

                if (m_nightTimer <= 20)
                {
                    this.transform.Rotate(new Vector3(0, 0, 70.0f / 20.0f));
                }
                else if (m_nightTimer <= 30)
                {
                    this.transform.Rotate(new Vector3(0, 0, -10.0f / 20.0f));
                }

                m_nightTimer++;
                break;

        }
    }

}
