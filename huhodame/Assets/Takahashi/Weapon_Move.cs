using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon_Move : MonoBehaviour
{
    GameObject Spot = null;
    GameObject Camera = null;

    //画像よ
    GameObject Weapon1 = null;
    GameObject Weapon2 = null;
    GameObject Weapon3 = null;
    GameObject Batu1 = null;
    GameObject Batu2 = null;
    GameObject Weapon1_nedan = null;
    GameObject Weapon2_nedan = null;
    GameObject Weapon3_nedan = null;

    //テキストの色
    Vector4 TextColor = new Vector4(0.8490566f, 0.5218349f, 0.03604484f, 1.0f);
    Vector4 TextColor_g = new Vector4(0.8490566f / 2.0f, 0.5218349f / 2.0f, 0.03604484f / 2.0f, 1.0f);
    Vector4 Pos;

    // Start is called before the first frame update
    void Start()
    {
        Spot = GameObject.Find("cannon_2_p");
        Camera = GameObject.Find("Main Camera");

        Weapon1 = GameObject.Find("Weapon1");
        Weapon2 = GameObject.Find("Weapon2");
        Weapon3 = GameObject.Find("Weapon3");
        Batu1 = GameObject.Find("Batu1");
        Batu2 = GameObject.Find("Batu2");
        Weapon1_nedan = GameObject.Find("Weapon1_Nedan");
        Weapon2_nedan = GameObject.Find("Weapon2_Nedan");
        Weapon3_nedan = GameObject.Find("Weapon3_Nedan");
    }

    // Update is called once per frame
    void Update()
    {
        Vector4 sp_color;

        //お金足りてる？
        //キャノン
        //Debug.Log(Camera.GetComponent<CamerMove>().NowMoney());
        if (Camera.GetComponent<CamerMove>().NowMoney() >= 500)
        {
            sp_color = Batu1.GetComponent<Text>().color;
            sp_color.w = 0.0f;
            Batu1.GetComponent<Text>().color = sp_color;
        }
        else
        {
            sp_color = Batu1.GetComponent<Text>().color;
            sp_color.w = 0.5f;
            Batu1.GetComponent<Text>().color = sp_color;
        }
        //ミサイル
        if (Camera.GetComponent<CamerMove>().NowMoney() >= 2000)
        {
            sp_color = Batu2.GetComponent<Text>().color;
            sp_color.w = 0.0f;
            Batu2.GetComponent<Text>().color = sp_color;
        }
        else
        {
            sp_color = Batu2.GetComponent<Text>().color;
            sp_color.w = 0.5f;
            Batu2.GetComponent<Text>().color = sp_color;
        }

        //選択状態
        int NowWeaponNom = Spot.GetComponent<Aim>().GetCurrentNum();
        Debug.Log(NowWeaponNom);

        switch (NowWeaponNom)
        {
            case 0:
                //color
                sp_color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                Weapon1.GetComponent<Image>().color = sp_color;
                sp_color = new Vector4(0.5f, 0.5f, 0.5f, 1.0f);
                Weapon2.GetComponent<Image>().color = sp_color;
                Weapon3.GetComponent<Image>().color = sp_color;
                Weapon1_nedan.GetComponent<Text>().color = TextColor;
                Weapon2_nedan.GetComponent<Text>().color = TextColor_g;
                Weapon3_nedan.GetComponent<Text>().color = TextColor_g;
                //pos
                Pos = Weapon1.transform.position;
                Pos.y = 520.0f;
                Weapon1.transform.position = Pos;
                Pos = Weapon2.transform.position;
                Pos.y = 530.0f;
                Weapon2.transform.position = Pos;
                Pos = Weapon3.transform.position;
                Pos.y = 530.0f;
                Weapon3.transform.position = Pos;

                Pos = Batu1.transform.position;
                Pos.y = 180.0f + 330.0f;
                Batu1.transform.position = Pos;
                Pos = Batu2.transform.position;
                Pos.y = 180.0f + 330.0f;
                Batu2.transform.position = Pos;

                Pos = Weapon1_nedan.transform.position;
                Pos.y = 140.0f + 330.0f;
                Weapon1_nedan.transform.position = Pos;
                Pos = Weapon2_nedan.transform.position;
                Pos.y = 150.0f + 330.0f;
                Weapon2_nedan.transform.position = Pos;
                Pos = Weapon3_nedan.transform.position;
                Pos.y = 150.0f + 330.0f;
                Weapon3_nedan.transform.position = Pos;

                break;
            case 2:
                //color
                sp_color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                Weapon2.GetComponent<Image>().color = sp_color;
                sp_color = new Vector4(0.5f, 0.5f, 0.5f, 1.0f);
                Weapon1.GetComponent<Image>().color = sp_color;
                Weapon3.GetComponent<Image>().color = sp_color;
                Weapon2_nedan.GetComponent<Text>().color = TextColor;
                Weapon1_nedan.GetComponent<Text>().color = TextColor_g;
                Weapon3_nedan.GetComponent<Text>().color = TextColor_g;
                //pos
                Pos = Weapon2.transform.position;
                Pos.y = 520.0f;
                Weapon2.transform.position = Pos;
                Pos = Weapon1.transform.position;
                Pos.y = 530.0f;
                Weapon1.transform.position = Pos;
                Pos = Weapon3.transform.position;
                Pos.y = 530.0f;
                Weapon3.transform.position = Pos;

                Pos = Batu1.transform.position;
                Pos.y = 170.0f + 330.0f;
                Batu1.transform.position = Pos;
                Pos = Batu2.transform.position;
                Pos.y = 180.0f + 330.0f;
                Batu2.transform.position = Pos;

                Pos = Weapon2_nedan.transform.position;
                Pos.y = 140.0f + 330.0f;
                Weapon2_nedan.transform.position = Pos;
                Pos = Weapon1_nedan.transform.position;
                Pos.y = 150.0f + 330.0f;
                Weapon1_nedan.transform.position = Pos;
                Pos = Weapon3_nedan.transform.position;
                Pos.y = 150.0f + 330.0f;
                Weapon3_nedan.transform.position = Pos;

                break;
            case 1:
                //color
                sp_color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                Weapon3.GetComponent<Image>().color = sp_color;
                sp_color = new Vector4(0.5f, 0.5f, 0.5f, 1.0f);
                Weapon1.GetComponent<Image>().color = sp_color;
                Weapon2.GetComponent<Image>().color = sp_color;
                Weapon3_nedan.GetComponent<Text>().color = TextColor;
                Weapon1_nedan.GetComponent<Text>().color = TextColor_g;
                Weapon2_nedan.GetComponent<Text>().color = TextColor_g;
                //pos
                Pos = Weapon3.transform.position;
                Pos.y = 520.0f;
                Weapon3.transform.position = Pos;
                Pos = Weapon1.transform.position;
                Pos.y = 530.0f;
                Weapon1.transform.position = Pos;
                Pos = Weapon2.transform.position;
                Pos.y = 530.0f;
                Weapon2.transform.position = Pos;

                Pos = Batu2.transform.position;
                Pos.y = 170.0f + 330.0f;
                Batu2.transform.position = Pos;
                Pos = Batu1.transform.position;
                Pos.y = 180.0f + 330.0f;
                Batu1.transform.position = Pos;

                Pos = Weapon3_nedan.transform.position;
                Pos.y = 140.0f + 330.0f;
                Weapon3_nedan.transform.position = Pos;
                Pos = Weapon1_nedan.transform.position;
                Pos.y = 150.0f + 330.0f;
                Weapon1_nedan.transform.position = Pos;
                Pos = Weapon2_nedan.transform.position;
                Pos.y = 150.0f + 330.0f;
                Weapon2_nedan.transform.position = Pos;

                break;
        }

    }
}
