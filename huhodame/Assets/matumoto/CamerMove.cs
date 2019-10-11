using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CamerMove : MonoBehaviour
{
    [SerializeField] GameObject[] m_Battery = new GameObject[2];
    int no = 0;
    public Text dollarText;
    private int dollar = 0;
    private int countevil = 0;
    private int count = 0;

    //スワップ用
    public GameObject A_Gate1;
    public GameObject A_Gate2;
    public GameObject B_Gate1;
    public GameObject B_Gate2;

    // Start is called before the first frame update
    void Start()
    {
        dollarText.text = dollar.ToString()+"＄";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            
            no++;
            no %= 2;
            Debug.Log(no);
            this.transform.position = m_Battery[no].transform.position;
            this.transform.rotation = m_Battery[no].transform.rotation;
            this.transform.parent = m_Battery[no].transform;

            //キー設定をスワップ
            KeyCode m_key = A_Gate1.GetComponent<Sensor>().GetKeyCode();
            A_Gate1.GetComponent<Sensor>().SetKeyCode(B_Gate1.GetComponent<Sensor>().GetKeyCode());
            B_Gate1.GetComponent<Sensor>().SetKeyCode(m_key);
            m_key = A_Gate2.GetComponent<Sensor>().GetKeyCode();
            A_Gate2.GetComponent<Sensor>().SetKeyCode(B_Gate2.GetComponent<Sensor>().GetKeyCode());
            B_Gate2.GetComponent<Sensor>().SetKeyCode(m_key);

        }
        if (countevil < ScoreManager.getdeath_evilHuman())
        {
            countevil++;
            dollar += 100 ;
            dollarText.text = dollar.ToString() + "＄";
        }
        if (count < ScoreManager.getdeath_normalHuman())
        {
            count++;
            dollar -= 20;
            dollarText.text = dollar.ToString() + "＄";
        }


    }

    //所持金を返す
    public int NowMoney()
    {
        return dollar;
    }
    //砲台Noを返す
    public int NowHoudai()
    {
        return no;
    }
}
