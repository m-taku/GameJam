using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapSensor : MonoBehaviour
{
    GameObject Camera = null;

    GameObject A_Waku = null;
    GameObject A_Waku_DataWaku = null;
    GameObject A_Waku_Check = null;
    GameObject A_Waku_Sensor1 = null;
    GameObject A_Waku_Sensor2 = null;
    GameObject B_Waku = null;
    GameObject B_Waku_DataWaku = null;
    GameObject B_Waku_Check = null;
    GameObject B_Waku_Sensor1 = null;
    GameObject B_Waku_Sensor2 = null;

    int BeNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera");

        A_Waku = GameObject.Find("A_Gate");
        A_Waku_DataWaku = GameObject.Find("A_Gate_DataWaku");
        A_Waku_Check = GameObject.Find("A_Gate_Check");
        A_Waku_Sensor1 = GameObject.Find("A_Gate_Sensor");
        A_Waku_Sensor2 = GameObject.Find("A_Gate_Sensor2");
        B_Waku = GameObject.Find("B_Gate");
        B_Waku_DataWaku = GameObject.Find("B_Gate_DataWaku");
        B_Waku_Check = GameObject.Find("B_Gate_Check");
        B_Waku_Sensor1 = GameObject.Find("B_Gate_Sensor");
        B_Waku_Sensor2 = GameObject.Find("B_Gate_Sensor2");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 YobiPos;

        if (BeNum!= Camera.GetComponent<CamerMove>().NowHoudai())
        {
            YobiPos = A_Waku.transform.position;
            A_Waku.transform.position = B_Waku.transform.position;
            B_Waku.transform.position = YobiPos;
            //
            YobiPos = A_Waku_DataWaku.transform.position;
            A_Waku_DataWaku.transform.position = B_Waku_DataWaku.transform.position;
            B_Waku_DataWaku.transform.position = YobiPos;
            //
            YobiPos = A_Waku_Check.transform.position;
            A_Waku_Check.transform.position = B_Waku_Check.transform.position;
            B_Waku_Check.transform.position = YobiPos;
            //
            YobiPos = A_Waku_Sensor1.transform.position;
            A_Waku_Sensor1.transform.position = B_Waku_Sensor1.transform.position;
            B_Waku_Sensor1.transform.position = YobiPos;
            //
            YobiPos = A_Waku_Sensor2.transform.position;
            A_Waku_Sensor2.transform.position = B_Waku_Sensor2.transform.position;
            B_Waku_Sensor2.transform.position = YobiPos;

            BeNum = Camera.GetComponent<CamerMove>().NowHoudai();
        }

    }
}
