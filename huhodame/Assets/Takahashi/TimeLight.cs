using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLight : MonoBehaviour
{
    public float timeOut; //時間のボーダー
    private float timeElapsed;
    int Timer = 0;
    GameTime.day Hoge_Day = GameTime.day.Morning;
    GameObject GameObj;
    public Material night_sky = null;
    public AudioSource[] sound;
    public int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponents<AudioSource>();
        GameObj = GameObject.Find("GameObject");
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        sound[num].Play();
        if (timeElapsed >= timeOut)
        {
            // Do anything
            LightMove();
            Timer++;

            timeElapsed = 0.0f;
        }

    }

    void LightMove()
    {
        Light light = this.GetComponent<Light>();

        if (Hoge_Day != GameObj.GetComponent<GameTime>().m_Day)
        {
            Timer = 0;
            Hoge_Day = GameObj.GetComponent<GameTime>().m_Day;
        }

        switch (GameObj.GetComponent<GameTime>().m_Day)
        {
            case GameTime.day.Morning:
                light.color = new Vector4(0.6985582f, 0.7487539f, 0.8867924f, 1.0f);
                num = 0;
                break;
            case GameTime.day.Noon:
                num = 1;
                if (Timer < 60)
                {
                    //light.color = new Vector4(1.0f, 0.8649839f, 0.8649839f, 1.0f);
                    Vector4 col = light.color;
                    col += new Vector4( (1.0f - 0.6985582f ) / 60.0f, (0.8649839f - 0.7487539f ) / 60.0f, (0.8649839f - 0.8867924f ) / 60.0f, 0.0f);
                    light.color = col;

                    this.transform.Rotate(new Vector3(0.0f, -45.0f / 60.0f, 0.0f));
                }

                break;
            case GameTime.day.Night:
                num = 2;
                //light.color = new Vector4(0.0773407f, 0.1126049f, 0.2075472f, 1.0f);
                if (Timer == 5)
                {
                    RenderSettings.skybox = night_sky;
                }

                if (Timer < 60)
                {
                    Vector4 col = light.color;
                    col += new Vector4((-0.3985582f ) / 60.0f, (-0.3487539f) / 60.0f, ( 0.1067924f ) / 60.0f, 0.0f);
                    light.color = col;

                    light.intensity -= 0.5f / 60.0f;
                    this.transform.Rotate(new Vector3(0.0f, -45.0f / 60.0f, 0.0f));

                }

                break;
        }
    }

}
