using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    private float interval = 0.0f;
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
         sound.Play();

    }

    // Update is called once per frame
    void Update()
    {
       
        interval += Time.deltaTime;
        if (interval >= 0.8f)
        {
            
            interval = 0.0f;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            Destroy(this.gameObject);
        }
    }
}
