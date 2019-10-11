using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonHuman : MonoBehaviour
{
    public GameObject[] Human;
    public GameObject Score;
    GameTime m_Time;
    int count = 0;
    int evilratio = 20;
    // Start is called before the first frame update
    void Start()
    {
        m_Time = Score.GetComponent<GameTime>();
        for(int i= 0;i<2;i++)
        {
            var na = Spoon();
            if (i > 1)
            {
                na.setevil(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((m_Time.m_GameTime / 1) - count >= 1)
        {
            Human obj = new Human();
            switch (m_Time.m_Day)
            {
                case GameTime.day.Morning:
                    evilratio = 0;
                    if (count % 5 == 0)
                    {
                        obj = Spoon();
                        evilratio = 60;
                    }
                    break;
                case GameTime.day.Noon:
                    obj = Spoon();
                    evilratio = 40;
                    break;
                case GameTime.day.Night:
                    if ((m_Time.m_GameTime / 1) >= 70)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            obj = Spoon();
                            evilratio = 0;
                            obj.speed = 40;
                            obj.setevil(true);
                        }
                    }
                    break;
            }
            if (evilratio >= Random.Range(0, 100))
            {
                obj.setevil(true);
            }
            count++;
        }
    }
    Human Spoon()
    {
        var na = Random.Range(0, Human.Length);
        var z_sa = Random.Range(-200, 200);
        var x_sa = Random.Range(-10, 10);
        var pos = new Vector3(transform.position.x+ x_sa, transform.position.y, transform.position.z + z_sa);
        var n = Instantiate(Human[na], pos, transform.rotation);
        return n.GetComponent<Human>();
        //if (20 >= Random.Range(0, 100))
        //{
        //    n.GetComponent<Human>().m_evil = true;
        //}
    }
}
