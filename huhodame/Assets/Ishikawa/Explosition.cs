using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosition : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
     
    }
    void OnCollisionEnter(Collision col)
    {
        sound.Play();
        // Debug.Log("fghnfger");
        Instantiate(explosion, new Vector3(transform.position.x,
            transform.position.y,
            transform.position.z),
           Quaternion.identity);
        explosion.GetComponent<CapsuleCollider>().enabled = true;
       
        Destroy(this.gameObject);
    }
}
