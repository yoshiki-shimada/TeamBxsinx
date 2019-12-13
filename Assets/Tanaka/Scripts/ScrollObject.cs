﻿//-----------------------------------------------
//センターレーンのオブジェクトを動かす
//-----------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public GameObject[] obj;
    public float speedX;
    public float startPosition;
    public float endPosition;
    //public bool pushYFlag;

    [SerializeField] private Animator[] animator;

    private float hori;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<GameObject>();
        GetComponent<Transform>();
        //pushYFlag = false;
    }


    // Update is called once per frame
    void Update()
    {
        //buttonflag();
        Move();
    }

    //”Y"ボタン操作
    //void buttonflag()
    //{
    //    if (Input.GetButtonDown("GamePad1_buttonY") && !pushYFlag) { pushYFlag = true; }
    //    else if (Input.GetButtonDown("GamePad1_buttonY") && pushYFlag) { pushYFlag = false; }
    //}

    //アタッチしたオブジェクトの移動操作
    void Move()
    {
        float tri = Input.GetAxis("GamePad1_LRTrigger");

        if (tri != 0)
        {
            for (int i = 0; i < animator.Length; i++)
            {
                animator[i].SetBool("RolFlag", true);
            }

            for(int i = 0; i < obj.Length; i++)
            {
                obj[i].transform.position += new Vector3(tri * speedX * Time.deltaTime, 0, 0);
            }
            ScrollEnd();
        }
        else
        {
            for (int i = 0; i < animator.Length; i++)
            {
                animator[i].SetBool("RolFlag", false);
            }
        }
    }

    //オブジェクトが決められた位置まで到達したときの処理
    void ScrollEnd()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            Vector3 Pos = obj[i].transform.position;
            if (obj[i].transform.position.x <= endPosition)
            {
                //Destroy(this.gameObject);
                obj[i].transform.position = new Vector3(startPosition, Pos.y, Pos.z);
            }
            else if (obj[i].transform.position.x >= startPosition)
            {
                //Destroy(this.gameObject);
                obj[i].transform.position = new Vector3(endPosition, Pos.y, Pos.z);
            }
        }
    }
}
