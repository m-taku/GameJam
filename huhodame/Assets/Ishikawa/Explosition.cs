using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosition : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    void OnCollisionEnter(Collision col)
    {
        // Debug.Log("fghnfger");
        Instantiate(explosion, new Vector3(transform.position.x,
            transform.position.y,
            transform.position.z),
           Quaternion.identity);
        Destroy(this.gameObject);
    }
}
