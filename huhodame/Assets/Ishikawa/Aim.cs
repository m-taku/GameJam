﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    //カーソルに使用するテクスチャ
    [SerializeField]
    private Texture2D cursor;
    [SerializeField]
    private GameObject[] bullet =new GameObject[3];
    [SerializeField]
    private Transform muzzle;
    private float bulletPower = 1000.0f;
    private float scroll;
    private int currentNum = 0;
    private float interVal = 0;
    private AudioSource[] sound;
    GameObject m_Camera = null;

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = GameObject.Find("Main Camera");

        //カーソルを用意したカーソルに変更
        Cursor.SetCursor(cursor, new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.ForceSoftware);
       sound = GetComponents<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        interVal += Time.deltaTime;
        scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0)
        {
            
            currentNum++;
            if (currentNum >= 3)
            {
                currentNum = 0;
            }
        }
        if (scroll < 0)
        {
           
            currentNum--;
            if (currentNum < 0)
            {
                currentNum = 2;
            }
        }
        if(currentNum == 0)
        {
            bulletPower = 27000.0f;
        }
        else if(currentNum ==1)
        {
            bulletPower = 9000.0f;
        }
        else if (currentNum == 2)
        {
            bulletPower = 17000.0f;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(ray.direction);
        //マウスの左クリックで撃つ。
        if (Input.GetButtonDown("Fire1"))
        {
            //if (Input.mousePosition.x > 100.0f&& Input.mousePosition.x< 400.0f
            //    &&Input.mousePosition.y >  50.0f&& Input.mousePosition.y < 220.0f)
            //{
                Shot();
            //}
        }
        Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit1;
        if (Physics.Raycast(ray1, out hit1, 1f, LayerMask.GetMask("Gun")))
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }
    void Shot()
    {
        if(interVal >= 0.5f)
        {
            if(currentNum == 0)
            {
                sound[currentNum].Play();
                interVal = 0.0f;
                var bulletInstance = Instantiate<GameObject>(bullet[currentNum], muzzle.position, muzzle.rotation);
                bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * bulletPower);
            }
            if (currentNum==2 && m_Camera.GetComponent<CamerMove>().NowMoney() >= 500/2)
            {
                m_Camera.GetComponent<CamerMove>().PlusMoney(500/2);

                sound[currentNum].Play();
                interVal = 0.0f;
                var bulletInstance = Instantiate<GameObject>(bullet[currentNum], muzzle.position, muzzle.rotation);
                bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * bulletPower);

            }
            if (currentNum == 1 && m_Camera.GetComponent<CamerMove>().NowMoney() >= 2000/2)
            {
                m_Camera.GetComponent<CamerMove>().PlusMoney(2000/2);

                sound[currentNum].Play();
                interVal = 0.0f;
                var bulletInstance = Instantiate<GameObject>(bullet[currentNum], muzzle.position, muzzle.rotation);
                bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * bulletPower);

            }
        }
        
    }

    //現在の武器Noを返す
    public int GetCurrentNum()
    {
        return currentNum;
    }
}
