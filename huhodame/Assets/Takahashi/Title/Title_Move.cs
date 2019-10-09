using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_Move : MonoBehaviour
{
    public enum mozi_syurui //文字の種類
    {
        Mozi_hu,
        Mozi_ho,
        Mozi_nyu,
        Mozi_koku,
        Mozi_da,
        Mozi_me,
        Mozi_zetu,
        Mozi_tai,
        Mozi_maru,
        Under1,
        Under2,
        Mozi_tai_hund,
    }
    public mozi_syurui Mozi_Syurui;
    int Timer;
    Vector3 DefPos; //保存されるデフォルトポジション
    Vector3 StartPos; //初期座標を入れる

    // Start is called before the first frame update
    void Start()
    {
        Vector4 sp_color = this.GetComponent<Image>().color;
        //sp_color.w = 0.0f;
        this.GetComponent<Image>().color = sp_color;
        Vector3 sp_position = this.transform.position;
        DefPos = sp_position;

        switch (Mozi_Syurui)
        {
            case mozi_syurui.Mozi_hu:
                //不 のアニメーション
                sp_position.x += 600.0f;
                break;
            case mozi_syurui.Mozi_ho:
                //法 のアニメーション



                break;
            case mozi_syurui.Mozi_nyu:
                //入 のアニメーション



                break;
            case mozi_syurui.Mozi_koku:
                //国 のアニメーション



                break;
            case mozi_syurui.Mozi_da:
                //ダ のアニメーション



                break;
            case mozi_syurui.Mozi_me:
                //メ のアニメーション



                break;
            case mozi_syurui.Mozi_zetu:
                //絶 のアニメーション



                break;
            case mozi_syurui.Mozi_tai:
                //対 のアニメーション



                break;
            case mozi_syurui.Mozi_maru:
                //。 のアニメーション



                break;
            case mozi_syurui.Under1:
                //アンダー1 のアニメーション



                break;
            case mozi_syurui.Under2:
                //アンダー2 のアニメーション



                break;
            case mozi_syurui.Mozi_tai_hund:
                //体の手 のアニメーション



                break;
        }

        this.transform.position = sp_position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 sp_position = this.transform.position;

        switch (Mozi_Syurui)
        {
            case mozi_syurui.Mozi_hu:
                //不 のアニメーション
                if (Timer == 0)
                {
                    StartPos = sp_position;
                }
                if (Timer <= 60)
                {
                    Vector3 move = StartPos - DefPos;
                    move /= 60.0f;
                    sp_position -= move;

                }

                break;
            case mozi_syurui.Mozi_ho:
                //法 のアニメーション



                break;
            case mozi_syurui.Mozi_nyu:
                //入 のアニメーション



                break;
            case mozi_syurui.Mozi_koku:
                //国 のアニメーション



                break;
            case mozi_syurui.Mozi_da:
                //ダ のアニメーション



                break;
            case mozi_syurui.Mozi_me:
                //メ のアニメーション



                break;
            case mozi_syurui.Mozi_zetu:
                //絶 のアニメーション



                break;
            case mozi_syurui.Mozi_tai:
                //対 のアニメーション



                break;
            case mozi_syurui.Mozi_maru:
                //。 のアニメーション



                break;
            case mozi_syurui.Under1:
                //アンダー1 のアニメーション



                break;
            case mozi_syurui.Under2:
                //アンダー2 のアニメーション



                break;
            case mozi_syurui.Mozi_tai_hund:
                //体の手 のアニメーション



                break;
        }

        this.transform.position = sp_position;
        Timer++;
    }
}
