using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    static int death_normalHuman = 0;           //善人を倒してしまった数
    static int death_evilHuman = 0;             //悪人を倒した数
    static int Escape_evilHuman = 0;            //通してしまった悪人の数
    // Start is called before the first frame update
    public static int getdeath_normalHuman()
    {
        return death_normalHuman;
    }
    public static int getdeath_evilHuman()
    {
        return death_evilHuman;
    }
    public static int getEscape_evilHuman()
    {
        return Escape_evilHuman;
    }
    public static void AddScore(bool furagu)
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
    public static void Escape(bool furagu)
    {
        if (furagu)
        {
            Escape_evilHuman++;
        }
    }
    public static void reset()
    {
        death_normalHuman = 0;           //善人を倒してしまった数
        death_evilHuman = 0;             //悪人を倒した数
       Escape_evilHuman = 0;            //通してしまった悪人の数
    }
}
