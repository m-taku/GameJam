using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultEffect : MonoBehaviour
{
    public float timeOut; //時間のボーダー
    private float timeElapsed;

    int Timer = 0;
    int Hyouzi = 0; //ロール演出用
    
    //演出用
    bool SaiseiFlag1 = false;
    bool SaiseiFlag2 = false;
    bool SaiseiFlag3 = false;
    bool SaiseiFlag1_ = false;
    bool SaiseiFlag2_ = false;
    bool SaiseiFlag3_ = false;
    int SaiseiTimer1 = 0;
    int SaiseiTimer2 = 0;

    //数ｩ
    int Dead_Akunin_Nom = 0;
    int Alive_Akunin_Nom = 0;
    int Dead_Zennin_Nom = 0;

    //スコア倍率
    public float Dead_Akunin_ScoreHosei = 0;
    public float Alive_Akunin_ScoreHosei = 0;
    public float Dead_Zennin_ScoreHosei = 0;

    //計算したスコアを入れる場所
    int Dead_Akunin_Score = 0;
    int Alive_Akunin_Score = 0;
    int Dead_Zennin_Score = 0;
    int FinalScore = 0;

    //ゲームオブジェクトぶちこみ場所
    GameObject Fade = null;
    GameObject Gun = null;
    GameObject Result_Text = null;
    GameObject Text1 = null; //倒した悪人テキスト
    GameObject Text2 = null; //生きた悪人テキスト
    GameObject Text3 = null; //倒した善人テキスト
    GameObject Text1_ = null; //倒した悪人スコア
    GameObject Text2_ = null; //生きた悪人スコア
    GameObject Text3_ = null; //倒した善人スコア
    GameObject Line = null; //ライン
    GameObject Score = null;
    GameObject Score2 = null;

    // Start is called before the first frame update
    void Start()
    {
        //準備
        Dead_Akunin_Nom = ScoreManager.getdeath_evilHuman();
        Alive_Akunin_Nom = ScoreManager.getEscape_evilHuman();
        Dead_Zennin_Nom = ScoreManager.getdeath_normalHuman();

        //画像のスタンバーイ
        Fade = GameObject.Find("Fade");
        Gun = GameObject.Find("Gun");
        Result_Text = GameObject.Find("Result_Text");
        Text1 = GameObject.Find("Text1");
        Text2 = GameObject.Find("Text2");
        Text3 = GameObject.Find("Text3");
        Text1_ = GameObject.Find("Text1_");
        Text2_ = GameObject.Find("Text2_");
        Text3_ = GameObject.Find("Text3_");
        Line = GameObject.Find("Line");
        Score = GameObject.Find("Text4_Score");
        Score2 = GameObject.Find("Text4_Score2");

        //非表示
        Vector4 sp_color = Fade.GetComponent<Image>().color;
        sp_color.w = 0.0f;
        Fade.GetComponent<Image>().color = sp_color;

        Gun.transform.Rotate(new Vector3(0, 0, -120.0f));

        sp_color = Result_Text.GetComponent<Text>().color;
        sp_color.w = 0.0f;
        Result_Text.GetComponent<Text>().color = sp_color;

        sp_color = Text1.GetComponent<Text>().color;
        sp_color.w = 0.0f;
        Text1.GetComponent<Text>().color = sp_color;

        sp_color = Text2.GetComponent<Text>().color;
        sp_color.w = 0.0f;
        Text2.GetComponent<Text>().color = sp_color;

        sp_color = Text3.GetComponent<Text>().color;
        sp_color.w = 0.0f;
        Text3.GetComponent<Text>().color = sp_color;

        sp_color = Text1_.GetComponent<Text>().color;
        sp_color.w = 0.0f;
        Text1_.GetComponent<Text>().color = sp_color;

        sp_color = Text2_.GetComponent<Text>().color;
        sp_color.w = 0.0f;
        Text2_.GetComponent<Text>().color = sp_color;

        sp_color = Text3_.GetComponent<Text>().color;
        sp_color.w = 0.0f;
        Text3_.GetComponent<Text>().color = sp_color;

        Vector3 pos = Line.transform.position;
        pos.x -= 1200.0f;
        Line.transform.position = pos;

        sp_color = Score.GetComponent<Text>().color;
        sp_color.w = 0.0f;
        Score.GetComponent<Text>().color = sp_color;
        Vector3 scl = Score.transform.localScale;
        scl.x = 5.0f;
        scl.y = 5.0f;
        Score.transform.localScale = scl;

        sp_color = Score2.GetComponent<Text>().color;
        sp_color.w = 0.0f;
        Score2.GetComponent<Text>().color = sp_color;
        scl = Score2.transform.localScale;
        scl.x = 5.0f;
        scl.y = 5.0f;
        Score2.transform.localScale = scl;

        Dead_Akunin_Score = (int)((float)Dead_Akunin_Nom * Dead_Akunin_ScoreHosei);
        Alive_Akunin_Score = (int)((float)Alive_Akunin_Nom * Alive_Akunin_ScoreHosei);
        Dead_Zennin_Score = (int)((float)Dead_Zennin_Nom * Dead_Zennin_ScoreHosei);
        FinalScore = Dead_Akunin_Score - Alive_Akunin_Score - Dead_Zennin_Score;
        if (FinalScore < 0) //負の数にはならない
        {
            FinalScore = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut)
        {
            // Do anything
            R_Effect();

            Timer++;
            timeElapsed = 0.0f;
        }

    }

    /// <summary>
    /// 実行用（見えにくいので分けた）
    /// </summary>
    void R_Effect()
    {
        //準備部分
        if(SaiseiFlag3 == false){
            if (Timer > 30 && Timer < 60) //フェード演出
            {
                Vector4 sp_color = Fade.GetComponent<Image>().color;
                sp_color.w += 0.02f;
                if (sp_color.w > 0.5f)
                {
                    sp_color.w = 0.5f;
                }
                Fade.GetComponent<Image>().color = sp_color;
            }

            if (Timer >= 60 && Timer < 120) //リザルトｫ
            {
                Vector4 sp_color = Result_Text.GetComponent<Text>().color;
                sp_color.w += 0.05f;
                if (sp_color.w > 1.0f)
                {
                    sp_color.w = 1.0f;
                }
                Result_Text.GetComponent<Text>().color = sp_color;

                if (Timer == 60)
                {
                    Result_Text.GetComponent<Text>().text = "R";
                }
                if (Timer == 64)
                {
                    Result_Text.GetComponent<Text>().text = "Re";
                }
                if (Timer == 68)
                {
                    Result_Text.GetComponent<Text>().text = "Res";
                }
                if (Timer == 72)
                {
                    Result_Text.GetComponent<Text>().text = "Resu";
                }
                if (Timer == 76)
                {
                    Result_Text.GetComponent<Text>().text = "Resul";
                }
                if (Timer == 80)
                {
                    Result_Text.GetComponent<Text>().text = "Result";
                }
            }
        }

        //スコア部分
        {
            if (Timer >= 120 && SaiseiFlag1 == false) //倒した悪人
            {
                if (SaiseiFlag1_ == false)
                {
                    Vector4 sp_color = Text1.GetComponent<Text>().color;
                    sp_color.w = 1.0f;
                    Text1.GetComponent<Text>().color = sp_color;
                    Hyouzi = 0;
                    SaiseiFlag1_ = true;
                }

                {
                    if (Hyouzi < 10)
                    {
                        Text1.GetComponent<Text>().text = "たおした  悪人　00" + Hyouzi + " 人";
                    }
                    else if (Hyouzi < 100)
                    {
                        Text1.GetComponent<Text>().text = "たおした  悪人　0" + Hyouzi + " 人";
                    }
                    else
                    {
                        Text1.GetComponent<Text>().text = "たおした  悪人　" + Hyouzi + " 人";
                    }
                    Hyouzi += 4;
                    if (Hyouzi > Dead_Akunin_Nom)
                    {
                        Vector4 sp_color = Text1_.GetComponent<Text>().color;
                        sp_color.w = 1.0f;
                        Text1_.GetComponent<Text>().color = sp_color;
                        Text1_.GetComponent<Text>().text = "+" + Dead_Akunin_Score;

                        Hyouzi = Dead_Akunin_Nom;
                        SaiseiFlag1 = true;
                    }
                }
            }

            if (SaiseiFlag1 == true)
            {
                SaiseiTimer1++;
            }

            if (SaiseiTimer1 >= 30 && SaiseiFlag1 == true && SaiseiFlag2 == false) //逃がした悪人
            {
                if (SaiseiFlag2_ == false)
                {
                    Vector4 sp_color = Text2.GetComponent<Text>().color;
                    sp_color.w = 1.0f;
                    Text2.GetComponent<Text>().color = sp_color;
                    Hyouzi = 0;
                    SaiseiFlag2_ = true;
                }

                {
                    if (Hyouzi < 10)
                    {
                        Text2.GetComponent<Text>().text = "通した 　悪人　00" + Hyouzi + " 人";
                    }
                    else if (Hyouzi < 100)
                    {
                        Text2.GetComponent<Text>().text = "通した 　悪人　0" + Hyouzi + " 人";
                    }
                    else
                    {
                        Text2.GetComponent<Text>().text = "通した 　悪人　" + Hyouzi + " 人";
                    }
                    Hyouzi += 4;
                    if (Hyouzi > Alive_Akunin_Nom)
                    {
                        Vector4 sp_color = Text2_.GetComponent<Text>().color;
                        sp_color.w = 1.0f;
                        Text2_.GetComponent<Text>().color = sp_color;
                        Text2_.GetComponent<Text>().text = "-" + Alive_Akunin_Score;

                        Hyouzi = Alive_Akunin_Nom;
                        SaiseiFlag2 = true;
                    }
                }
            }

            if (SaiseiFlag2 == true)
            {
                SaiseiTimer2++;
            }

            if (SaiseiTimer2 >= 30 && SaiseiFlag2 == true && SaiseiFlag3 == false) //殺した善人
            {
                if (SaiseiFlag3_ == false)
                {
                    Vector4 sp_color = Text3.GetComponent<Text>().color;
                    sp_color.w = 1.0f;
                    Text3.GetComponent<Text>().color = sp_color;
                    Hyouzi = 0;
                    SaiseiFlag3_ = true;
                }

                {
                    if (Hyouzi < 10)
                    {
                        Text3.GetComponent<Text>().text = "たおした　善人　00" + Hyouzi + " 人";
                    }
                    else if (Hyouzi < 100)
                    {
                        Text3.GetComponent<Text>().text = "たおした　善人　0" + Hyouzi + " 人";
                    }
                    else
                    {
                        Text3.GetComponent<Text>().text = "たおした　善人　" + Hyouzi + " 人";
                    }
                    Hyouzi += 4;
                    if (Hyouzi > Dead_Zennin_Nom)
                    {
                        Vector4 sp_color = Text3_.GetComponent<Text>().color;
                        sp_color.w = 1.0f;
                        Text3_.GetComponent<Text>().color = sp_color;
                        Text3_.GetComponent<Text>().text = "-" + Dead_Zennin_Score;

                        Hyouzi = Dead_Zennin_Nom;
                        SaiseiFlag3 = true;
                        Timer = 0;
                    }
                }
            }

        }

        //最終スコア表示
        if(SaiseiFlag3 == true)
        {
            //ライン移動
            if (Timer >= 30 && Timer < 70)
            {
                Vector3 pos = Line.transform.position;
                pos.x += 1260.0f / 40.0f;
                Line.transform.position = pos;
            }
            if (Timer >= 70 && Timer < 80)
            {
                Vector3 pos = Line.transform.position;
                pos.x -= 60.0f / 10.0f;
                Line.transform.position = pos;
            }

            //スコア！！！
            if (Timer == 120)
            {
                Vector4 sp_color = Score.GetComponent<Text>().color;
                sp_color.w = 1.0f;
                Score.GetComponent<Text>().color = sp_color;

                Score.GetComponent<Text>().text = "SCORE:" + FinalScore;
                Score2.GetComponent<Text>().text = "SCORE:" + FinalScore;

            }
            if (Timer >= 120 && Timer < 150)
            {
                Vector3 scl = Score.transform.localScale;
                scl.x -= 4.8f / 30.0f;
                scl.y -= 4.8f / 30.0f;
                Score.transform.localScale = scl;
                Score2.transform.localScale = scl;

                Gun.transform.Rotate(new Vector3(0, 0, 130.0f / 30.0f));

            }

            if (Timer == 150)
            {
                Vector4 sp_color = Score2.GetComponent<Text>().color;
                sp_color.w = 0.5f;
                Score2.GetComponent<Text>().color = sp_color;
            }

            if (Timer >= 150 && Timer < 160)
            {
                Vector3 scl = Score.transform.localScale;
                scl.x += 0.1f / 10.0f;
                scl.y += 0.1f / 10.0f;
                Score.transform.localScale = scl;

                scl = Score2.transform.localScale;
                scl.x += 1.0f / 10.0f;
                scl.y += 1.0f / 10.0f;
                Score2.transform.localScale = scl;

                Vector4 sp_color = Score2.GetComponent<Text>().color;
                sp_color.w -= 0.05f;
                if (sp_color.w < 0.0f)
                {
                    sp_color.w = 0.0f;
                }
                Score2.GetComponent<Text>().color = sp_color;

                Gun.transform.Rotate(new Vector3(0, 0, -10.0f / 10.0f));

            }
        }

    }

}

