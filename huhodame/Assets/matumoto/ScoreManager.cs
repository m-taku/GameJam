using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    int death_normalHuman = 0;
    int death_evilHuman = 0;
    int BonusHuman = 0;             //?
    int Escape_evilHuman = 0;
    // Start is called before the first frame update
    void Start()
    {
        death_normalHuman = 0;
        death_evilHuman = 0;
        BonusHuman = 0;
        Escape_evilHuman = 0;
        Debug.Log(Escape_evilHuman);
    }
    private void Update()
    {

    }
    public void AddScore(bool furagu)
    {
        if(furagu)
        {
            death_evilHuman++;
        }
        else
        {
            death_normalHuman++;
        }
    }
    public void AddBonusScore()
    {
        BonusHuman++;
    }
    public void Escape(bool furagu)
    {
        if (furagu)
        {

            Escape_evilHuman += 1;
        }
    }
}
