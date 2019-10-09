using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonHuman : MonoBehaviour
{
    public GameObject[] Human;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(i>=100)
        {
            var na = Random.Range(0,Human.Length); 
            i = 0;
            //Debug.Log(transform.rotation);
            var sa =  Random.Range(-200, 200);
            var pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + sa);
            var n = Instantiate(Human[na], pos, transform.rotation);
            if (20 >= Random.Range(0, 100))
            {
                n.GetComponent<Human>().m_Illegal_entry = true;
            }
        }
        else
        {
            i++;
        }
    }
}
