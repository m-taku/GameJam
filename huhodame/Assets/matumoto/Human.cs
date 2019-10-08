using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] float speed = 20.0f;
    public bool m_Illegal_entry = false;
    enum MyNo
    {
        nasi,
        knife,
        fakeknife,
        gun,
        gunfake,
    };
    [SerializeField] MyNo naaaa;
    // Start is called before the first frame update
    void Start()
    {
        if (m_Illegal_entry)
        {
            Debug.Log("nuiaefhw");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.tag == "end point")
        {
            //ここでスコアを減算する
            Destroy(this.transform.gameObject);   
        }
    }
}
