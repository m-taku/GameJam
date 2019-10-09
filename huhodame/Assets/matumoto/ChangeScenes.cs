using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    bool m_scene = false;
    [SerializeField] int No;
    private void Update()
    {
        if (m_scene)
        {
            Change_Scenes(No);
        }
    }
    public void Change()
    {
        m_scene = true;
    }
    void Change_Scenes(int No)
    {
        SceneManager.LoadScene(No);
    }
}
