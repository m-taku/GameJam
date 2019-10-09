using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Move : MonoBehaviour
{
    public float movespeed = 1.0f;
    public float MoveLimit = 13.8f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-movespeed, 0, 0);
        if (transform.position.x <= -MoveLimit)
        {
            transform.position = new Vector3(MoveLimit, transform.position.y, transform.position.z);
        }
    }

}
