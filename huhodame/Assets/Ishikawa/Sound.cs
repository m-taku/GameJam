﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
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
        
    }
}
