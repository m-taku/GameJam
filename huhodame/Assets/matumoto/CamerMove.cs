using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMove : MonoBehaviour
{
    [SerializeField] GameObject[] m_Battery = new GameObject[2];
    int no = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            
            no++;
            no %= 2;
            Debug.Log(no);
            this.transform.position = m_Battery[no].transform.position;
            this.transform.rotation = m_Battery[no].transform.rotation;
            this.transform.parent = m_Battery[no].transform;
        }
    }
}
