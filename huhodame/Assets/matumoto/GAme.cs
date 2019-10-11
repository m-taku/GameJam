using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAme : MonoBehaviour
{
    [SerializeField] GameObject obj = null;
    [SerializeField] string m_name = null;
    public bool furag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_name!="NULL")
        {
            if (Input.GetButton(m_name))
            {
                obj.GetComponent<ChangeScenes>().Change();
            }
        }
        else
        {
            if(furag)
            {

                obj.GetComponent<ChangeScenes>().Change();
            }
        }
    }
}
