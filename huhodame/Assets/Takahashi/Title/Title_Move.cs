using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_Move : MonoBehaviour
{
    public float timeOut; //時間のボーダー
    private float timeElapsed;

    public enum Mozi_syurui //文字の種類
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
    public Mozi_syurui Mozi_Syurui;
    int Timer;
    Vector3 DefPos; //保存されるデフォルトポジション
    Vector3 StartPos; //初期座標を入れる
    Vector3 GoalPos; //終点座標を入れる
    bool SetupFlag = false; //準備が終わったらtrueにする
    Vector3 sc;

    bool HitoFlag = false;
    int Hito_Timer = 0; //人を動かす用
    bool Hito_MoveFlag = false; //前か後か

    // Start is called before the first frame update
    void Start()
    {
        Vector4 sp_color = this.GetComponent<Image>().color;
        sp_color.w = 0.0f;
        this.GetComponent<Image>().color = sp_color;
        Vector3 sp_position = this.transform.position;
        DefPos = sp_position;
        Vector3 sp_scale;

        switch (Mozi_Syurui)
        {
            case Mozi_syurui.Mozi_hu:
                //不 のアニメーション
                sp_position.x -= 600.0f;
                break;
            case Mozi_syurui.Mozi_ho:
                //法 のアニメーション
                sp_position.y -= 600.0f;

                break;
            case Mozi_syurui.Mozi_nyu:
                //入 のアニメーション
                sp_position.x += 600.0f;
                break;
            case Mozi_syurui.Mozi_koku:
                //国 のアニメーション
                sp_position.y += 600.0f;
                break;
            //case mozi_syurui.Mozi_da:
            //    //ダ のアニメーション

            //    break;
            //case mozi_syurui.Mozi_me:
            //    //メ のアニメーション

            //    break;
            case Mozi_syurui.Mozi_zetu:
                //絶 のアニメーション
                sp_scale = this.transform.localScale;
                sp_scale.x = 0.0f;
                sp_scale.y = 1.0f;
                sp_scale.z = 1.0f;
                this.transform.localScale = sp_scale;
                break;
            case Mozi_syurui.Mozi_tai:
                //対 のアニメーション
                sp_scale = this.transform.localScale;
                sp_scale.x = 0.0f;
                sp_scale.y = 1.0f;
                sp_scale.z = 1.0f;
                this.transform.localScale = sp_scale;
                break;
            //case mozi_syurui.Mozi_maru:
            //    //。 のアニメーション
            //    break;
            case Mozi_syurui.Under1:
                //アンダー1 のアニメーション
                sp_scale = this.transform.localScale;
                sp_scale.x = 0.0f;
                sp_scale.y = 0.0f;
                sp_scale.z = 1.0f;
                this.transform.localScale = sp_scale;
                break;
            case Mozi_syurui.Under2:
                //アンダー2 のアニメーション
                sp_scale = this.transform.localScale;
                sp_scale.x = 1.0f;
                sp_scale.y = 0.0f;
                sp_scale.z = 1.0f;
                this.transform.localScale = sp_scale;
                break;
            //case mozi_syurui.Mozi_tai_hund:
            //    //体の手 のアニメーション
            //    break;
        }

        this.transform.position = sp_position;

    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut)
        {
            // Do anything
            if (SetupFlag == false) //じゅんびちう
            {
                TitleSetup();
            }
            else //待機アニメーション！
            {
                TitleWait();
            }

            //遷移さん
            if (SetupFlag == false && Timer >= 180)
            {
                SetupFlag = true;
            }
            //ひとひと
            if (SetupFlag == false && Timer == 61)
            {
                HitoFlag = true;
            }
                if (HitoFlag == true)
            {
                HitoMove();
            }

            timeElapsed = 0.0f;
        }

    }

    void TitleSetup()
    {
        Vector3 sp_position = this.transform.position;

        switch (Mozi_Syurui)
        {
            case Mozi_syurui.Mozi_hu:
                //不 のアニメーション
                if (Timer == 0) //準備
                {
                    StartPos = sp_position;
                    GoalPos = DefPos;
                    GoalPos.x += 10.0f;
                }
                if (Timer <= 20) //オーバーラン
                {
                    Vector3 move = StartPos - GoalPos;
                    move /= 20.0f;
                    sp_position -= move;
                    //不透明度！
                    Vector4 sp_color = this.GetComponent<Image>().color;
                    sp_color.w += 0.05f;
                    if (sp_color.w > 1.0f)
                    {
                        sp_color.w = 1.0f;
                    }
                    this.GetComponent<Image>().color = sp_color;
                }
                //戻ります
                if (Timer == 20) //準備
                {
                    StartPos = sp_position;
                    GoalPos = DefPos;
                }
                if (Timer > 20 && Timer <= 30) //オーバーラン
                {
                    Vector3 move = StartPos - GoalPos;
                    move /= 10.0f;
                    sp_position -= move;
                }
                break;
            //.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+
            case Mozi_syurui.Mozi_ho:
                //法 のアニメーション
                if (Timer == 10) //準備
                {
                    StartPos = sp_position;
                    GoalPos = DefPos;
                    GoalPos.y += 10.0f;
                }
                if (Timer > 10 && Timer <= 30) //オーバーラン
                {
                    Vector3 move = StartPos - GoalPos;
                    move /= 20.0f;
                    sp_position -= move;
                    //不透明度！
                    Vector4 sp_color = this.GetComponent<Image>().color;
                    sp_color.w += 0.05f;
                    if (sp_color.w > 1.0f)
                    {
                        sp_color.w = 1.0f;
                    }
                    this.GetComponent<Image>().color = sp_color;
                }
                //戻ります
                if (Timer == 30) //準備
                {
                    StartPos = sp_position;
                    GoalPos = DefPos;
                }
                if (Timer > 30 && Timer <= 50) //オーバーラン
                {
                    Vector3 move = StartPos - GoalPos;
                    move /= 10.0f;
                    sp_position -= move;
                }
                break;
            //.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+
            case Mozi_syurui.Mozi_nyu:
                //入 のアニメーション
                if (Timer == 30) //準備
                {
                    StartPos = sp_position;
                    GoalPos = DefPos;
                    GoalPos.x -= 10.0f;
                }
                if (Timer > 30 && Timer <= 50) //オーバーラン
                {
                    Vector3 move = StartPos - GoalPos;
                    move /= 20.0f;
                    sp_position -= move;
                    //不透明度！
                    Vector4 sp_color = this.GetComponent<Image>().color;
                    sp_color.w += 0.05f;
                    if (sp_color.w > 1.0f)
                    {
                        sp_color.w = 1.0f;
                    }
                    this.GetComponent<Image>().color = sp_color;
                }
                //戻ります
                if (Timer == 50) //準備
                {
                    StartPos = sp_position;
                    GoalPos = DefPos;
                }
                if (Timer > 50 && Timer <= 60) //オーバーラン
                {
                    Vector3 move = StartPos - GoalPos;
                    move /= 10.0f;
                    sp_position -= move;
                }
                break;
            //.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+
            case Mozi_syurui.Mozi_koku:
                //国 のアニメーション
                if (Timer == 50) //準備
                {
                    StartPos = sp_position;
                    GoalPos = DefPos;
                    GoalPos.y -= 10.0f;
                }
                if (Timer > 50 && Timer <= 70) //オーバーラン
                {
                    Vector3 move = StartPos - GoalPos;
                    move /= 20.0f;
                    sp_position -= move;
                    //不透明度！
                    Vector4 sp_color = this.GetComponent<Image>().color;
                    sp_color.w += 0.05f;
                    if (sp_color.w > 1.0f)
                    {
                        sp_color.w = 1.0f;
                    }
                    this.GetComponent<Image>().color = sp_color;
                }
                //戻ります
                if (Timer == 70) //準備
                {
                    StartPos = sp_position;
                    GoalPos = DefPos;
                }
                if (Timer > 70 && Timer <= 90) //オーバーラン
                {
                    Vector3 move = StartPos - GoalPos;
                    move /= 10.0f;
                    sp_position -= move;
                }
                break;
            //.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+
            case Mozi_syurui.Mozi_da:
                //ダ のアニメーション
                if (Timer == 80) //準備
                {
                    StartPos = new Vector3(5.0f, 5.0f, 1.0f);
                    GoalPos = new Vector3(0.8f, 0.8f, 1.0f);
                    this.transform.localScale = StartPos;
                }
                if (Timer > 80 && Timer <= 90) //オーバーラン
                {
                    Vector3 move = StartPos - GoalPos;
                    move.x /= 20.0f;
                    move.y /= 20.0f;
                    sc = this.transform.localScale + move;
                    //不透明度！
                    Vector4 sp_color = this.GetComponent<Image>().color;
                    sp_color.w += 0.1f;
                    if (sp_color.w > 1.0f)
                    {
                        sp_color.w = 1.0f;
                    }
                    this.GetComponent<Image>().color = sp_color;
                }
                //戻ります
                if (Timer == 90) //準備
                {
                    StartPos = this.transform.localScale;
                    GoalPos = new Vector3(1.0f, 1.0f, 1.0f);
                }
                if (Timer > 90 && Timer <= 100) //オーバーラン
                {
                    Vector3 move = StartPos - GoalPos;
                    move.x /= 10.0f;
                    move.y /= 10.0f;
                    move *= -1.0f;
                    sc = this.transform.localScale + move;
                }
                this.transform.localScale = sc;
                break;
            //.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+
            case Mozi_syurui.Mozi_me:
                //メ のアニメーション
                if (Timer == 85) //準備
                {
                    StartPos = new Vector3(5.0f, 5.0f, 1.0f);
                    GoalPos = new Vector3(0.8f, 0.8f, 1.0f);
                    this.transform.localScale = StartPos;
                }
                if (Timer > 85 && Timer <= 95) //オーバーラン
                {
                    Vector3 move = StartPos - GoalPos;
                    move.x /= 20.0f;
                    move.y /= 20.0f;
                    sc = this.transform.localScale + move;
                    //不透明度！
                    Vector4 sp_color = this.GetComponent<Image>().color;
                    sp_color.w += 0.1f;
                    if (sp_color.w > 1.0f)
                    {
                        sp_color.w = 1.0f;
                    }
                    this.GetComponent<Image>().color = sp_color;
                }
                //戻ります
                if (Timer == 95) //準備
                {
                    StartPos = this.transform.localScale;
                    GoalPos = new Vector3(1.0f, 1.0f, 1.0f);
                }
                if (Timer > 95 && Timer <= 105) //オーバーラン
                {
                    Vector3 move = StartPos - GoalPos;
                    move.x /= 10.0f;
                    move.y /= 10.0f;
                    move *= -1.0f;
                    sc = this.transform.localScale + move;
                }
                this.transform.localScale = sc;
                break;
            //.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+
            case Mozi_syurui.Mozi_zetu:
                //絶 のアニメーション
                if (Timer > 105 && Timer <= 115)
                {
                    Vector3 scl = this.transform.localScale;
                    scl.x += 2.0f / 10.0f;
                    scl.y += (0.8f / 10.0f) * -1.0f;
                    this.transform.localScale = scl;
                    //不透明度！
                    Vector4 sp_color = this.GetComponent<Image>().color;
                    sp_color.w += 0.05f;
                    if (sp_color.w > 1.0f)
                    {
                        sp_color.w = 1.0f;
                    }
                    this.GetComponent<Image>().color = sp_color;
                }
                if (Timer > 115 && Timer <= 125)
                {
                    Vector3 scl = this.transform.localScale;
                    scl.x += (1.2f / 10.0f) * -1.0f;
                    scl.y += 1.0f / 10.0f;
                    this.transform.localScale = scl;
                    //不透明度！
                    Vector4 sp_color = this.GetComponent<Image>().color;
                    sp_color.w += 0.05f;
                    if (sp_color.w > 1.0f)
                    {
                        sp_color.w = 1.0f;
                    }
                    this.GetComponent<Image>().color = sp_color;
                }
                if (Timer > 125 && Timer <= 135)
                {
                    Vector3 scl = this.transform.localScale;
                    scl.x += 0.2f / 10.0f;
                    scl.y += (0.2f / 10.0f) * -1.0f;
                    this.transform.localScale = scl;
                    //不透明度！
                    Vector4 sp_color = this.GetComponent<Image>().color;
                    sp_color.w += 0.05f;
                    if (sp_color.w > 1.0f)
                    {
                        sp_color.w = 1.0f;
                    }
                    this.GetComponent<Image>().color = sp_color;
                }
                break;
            //.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+
            case Mozi_syurui.Mozi_tai:
                //対 のアニメーション
                if (Timer > 125 && Timer <= 135)
                {
                    Vector3 scl = this.transform.localScale;
                    scl.x += 2.0f / 10.0f;
                    scl.y += (0.8f / 10.0f) * -1.0f;
                    this.transform.localScale = scl;
                    //不透明度！
                    Vector4 sp_color = this.GetComponent<Image>().color;
                    sp_color.w += 0.05f;
                    if (sp_color.w > 1.0f)
                    {
                        sp_color.w = 1.0f;
                    }
                    this.GetComponent<Image>().color = sp_color;
                }
                if (Timer > 135 && Timer <= 145)
                {
                    Vector3 scl = this.transform.localScale;
                    scl.x += (1.2f / 10.0f) * -1.0f;
                    scl.y += 1.0f / 10.0f;
                    this.transform.localScale = scl;
                    //不透明度！
                    Vector4 sp_color = this.GetComponent<Image>().color;
                    sp_color.w += 0.05f;
                    if (sp_color.w > 1.0f)
                    {
                        sp_color.w = 1.0f;
                    }
                    this.GetComponent<Image>().color = sp_color;
                }
                if (Timer > 145 && Timer <= 155)
                {
                    Vector3 scl = this.transform.localScale;
                    scl.x += 0.2f / 10.0f;
                    scl.y += (0.2f / 10.0f) * -1.0f;
                    this.transform.localScale = scl;
                }
                break;
            //.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+
            case Mozi_syurui.Mozi_maru:
                //。 のアニメーション
                if (Timer > 150 && Timer <= 170)
                {
                    this.transform.Rotate(new Vector3(0, 0, 360.0f / 20.0f));
                    //不透明度！
                    Vector4 sp_color = this.GetComponent<Image>().color;
                    sp_color.w += 0.05f;
                    if (sp_color.w > 1.0f)
                    {
                        sp_color.w = 1.0f;
                    }
                    this.GetComponent<Image>().color = sp_color;
                }
                break;
            //.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+
            case Mozi_syurui.Under1:

                //アンダー1 のアニメーション
                if (Timer == 10) //準備
                {
                    StartPos = new Vector3(0.0f, 0.0f, 1.0f);
                    GoalPos = new Vector3(1.2f, 1.2f, 1.0f);
                }
                if (Timer > 10 && Timer <= 30) //オーバーラン
                {
                    Vector3 move = GoalPos - StartPos;
                    move.x /= 20.0f;
                    move.y /= 20.0f;
                    sc = this.transform.localScale + move;
                    //不透明度！
                    Vector4 sp_color = this.GetComponent<Image>().color;
                    sp_color.w += 0.05f;
                    if (sp_color.w > 1.0f)
                    {
                        sp_color.w = 1.0f;
                    }
                    this.GetComponent<Image>().color = sp_color;
                }
                //戻ります
                if (Timer == 30) //準備
                {
                    StartPos = this.transform.localScale;
                    GoalPos = new Vector3(1.0f, 1.0f, 1.0f);
                }
                if (Timer > 30 && Timer <= 40) //オーバーラン
                {
                    Vector3 move = StartPos - GoalPos;
                    move.x /= 10.0f;
                    move.y /= 10.0f;
                    move *= -1.0f;
                    sc = this.transform.localScale + move;
                }
                this.transform.localScale = sc;
                break;
            //.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+
            case Mozi_syurui.Under2:
                //アンダー2 のアニメーション
                if (Timer > 135 && Timer <= 145)
                {
                    Vector3 scl = this.transform.localScale;
                    scl.y += 1.2f / 10.0f;
                    this.transform.localScale = scl;
                    //不透明度！
                    Vector4 sp_color = this.GetComponent<Image>().color;
                    sp_color.w += 0.05f;
                    if (sp_color.w > 1.0f)
                    {
                        sp_color.w = 1.0f;
                    }
                    this.GetComponent<Image>().color = sp_color;
                }
                if (Timer > 145 && Timer <= 155)
                {
                    Vector3 scl = this.transform.localScale;
                    scl.y += (0.4f / 10.0f) * -1.0f;
                    this.transform.localScale = scl;
                    //不透明度！
                    Vector4 sp_color = this.GetComponent<Image>().color;
                    sp_color.w += 0.05f;
                    if (sp_color.w > 1.0f)
                    {
                        sp_color.w = 1.0f;
                    }
                    this.GetComponent<Image>().color = sp_color;
                }
                if (Timer > 155 && Timer <= 165)
                {
                    Vector3 scl = this.transform.localScale;
                    scl.y += 0.2f / 10.0f;
                    this.transform.localScale = scl;
                }

                break;
            //.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+
            case Mozi_syurui.Mozi_tai_hund:
                //体の手 のアニメーション
                if (Timer > 150 && Timer <= 170)
                {
                    //不透明度！
                    Vector4 sp_color = this.GetComponent<Image>().color;
                    sp_color.w += 0.05f;
                    if (sp_color.w > 1.0f)
                    {
                        sp_color.w = 1.0f;
                    }
                    this.GetComponent<Image>().color = sp_color;
                }
                break;

        }

        this.transform.position = sp_position;
        Timer++;
    }

    void TitleWait()
    {
        switch (Mozi_Syurui)
        {
            //.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+.｡*ﾟ+.*.｡ﾟ+..｡*ﾟ+
            case Mozi_syurui.Mozi_tai_hund:
                //体の手 のアニメーション
                if (Timer > 10 && Timer <= 20) //オーバーラン
                {
                    Vector3 scl = this.transform.localScale;
                    scl.x += 0.2f / 10.0f;
                    scl.y += 0.2f / 10.0f;
                    this.transform.localScale = scl;
                }
                if (Timer > 20 && Timer <= 30) //オーバーラン
                {
                    Vector3 scl = this.transform.localScale;
                    scl.x -= 0.2f / 10.0f;
                    scl.y -= 0.2f / 10.0f;
                    this.transform.localScale = scl;
                }
                if (Timer > 30 && Timer <= 40) //オーバーラン
                {
                    Vector3 scl = this.transform.localScale;
                    scl.x += 0.2f / 10.0f;
                    scl.y += 0.2f / 10.0f;
                    this.transform.localScale = scl;
                }
                if (Timer > 40 && Timer <= 50) //オーバーラン
                {
                    Vector3 scl = this.transform.localScale;
                    scl.x -= 0.2f / 10.0f;
                    scl.y -= 0.2f / 10.0f;
                    this.transform.localScale = scl;
                }
                break;
        }

        Timer++;
        if (Timer > 180)
        {
            Timer = 0;
        }
    }

    void HitoMove()
    {
        if (Mozi_Syurui == Mozi_syurui.Mozi_nyu)
        {
            Vector3 sp_position = this.transform.position;
            if (Hito_MoveFlag ==false)
            {
                sp_position.x += 0.5f;
            }
            else
            {
                sp_position.x -= 0.5f;
            }
            this.transform.position = sp_position;
        }

        Hito_Timer++;
        if (Hito_Timer > 20)
        {
            Hito_Timer = 0;
            if (Hito_MoveFlag == false)
            {
                Hito_MoveFlag = true;
            }
            else
            {
                Hito_MoveFlag = false;
            }
        }
    }
}
