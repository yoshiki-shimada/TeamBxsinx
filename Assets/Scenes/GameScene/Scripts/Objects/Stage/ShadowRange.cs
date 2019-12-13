﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowRange : MonoBehaviour
{
    SoundManager PopShadow;

    private Renderer plane;
    private Collider[] collider;
    private SolidRange[] Solid;

    private ParticleSystem Solidps;
    public ParticleSystem enemyps
    {
        get { return Solidps; }
    }

    // 0:薄い影の範囲 1:3D影の範囲
    [SerializeField] private float shadowRange = 1.2f;
    public float Shadowrange
    {
        set { shadowRange = value; }
    }

    enum ShadowMode:sbyte
    {
        Nothing,
        Plane,
        Solid,
    }
    ShadowMode NowMode = ShadowMode.Nothing;
    ShadowMode PrevMode = ShadowMode.Nothing;

    // Start is called before the first frame update
    void Start()
    {
        GetShadow();
        GetRange();
        PopShadow = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(collider[0].transform.localPosition.x<=shadowRange &&
            collider[0].transform.localPosition.x >= -shadowRange &&
            collider[0].transform.localPosition.y >= -1.5f)
        {
            NowMode = ShadowMode.Plane;

            for (int i = 0; i < Solid.Length; i++)
            {
                if (Solid[i].CheckSolidRange(collider[0].transform.position))
                {
                    NowMode = ShadowMode.Solid;
                    if (PrevMode != ShadowMode.Solid)
                    {
                        ChangeShadowPhase(0.7f, 0.1f, collider[0].gameObject);
                        ChangeShadowPhase(0f, 0.1f, plane.gameObject);

                        Solidps.Play();
                        PopShadow.popshadowSE();
                        StartCoroutine(Shadow_enable(true));
                        //Debug.Log("SolidRangeIn");
                    }
                    break;
                }
            }
            if (NowMode == ShadowMode.Plane)
            {
                if (PrevMode == ShadowMode.Nothing)
                {
                    ChangeShadowPhase(0.7f, 0.4f, plane.gameObject);
                }
                else if (PrevMode == ShadowMode.Solid)
                {
                    ChangeShadowPhase(0f, 0.1f, collider[0].gameObject);
                    ChangeShadowPhase(0.7f, 0.1f, plane.gameObject);
                    StartCoroutine(Shadow_enable(false));
                    //Debug.Log("SolidRangeOut");
                }
            }
        }
        else
        {
            NowMode = ShadowMode.Nothing;
            if (PrevMode == ShadowMode.Plane) {
                ChangeShadowPhase(0f, 0.4f,plane.gameObject);
            }else if (PrevMode == ShadowMode.Solid)
            {
                
                ChangeShadowPhase(0f, 0.1f, collider[0].gameObject);
                ChangeShadowPhase(0f, 0.1f, plane.gameObject);
                StartCoroutine(Shadow_enable(false));
            }
              
        }
        PrevMode = NowMode;
    }

    void GetShadow()
    {
        collider = this.transform.GetChild(0).GetComponents<Collider>();
        plane = collider[0].transform.GetChild(0).GetComponent<Renderer>();

    }

    public void GetRange()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Shadow3DRange");
        Solid = new SolidRange[obj.Length];
        for (int i = 0; i < obj.Length; i++)
            Solid[i] = obj[i].GetComponent<SolidRange>();

        Solidps = collider[0].transform.GetComponentInChildren<ParticleSystem>();

    }

    void ChangeShadowPhase(float a,float time,GameObject game)
    {
        iTween.Stop(game);
        iTween.ColorTo(game, iTween.Hash(
    "a", a,
    "time", time,
    "delay", 0.01f));

    }

    IEnumerator Shadow_enable(bool enable)
    {
        yield return new WaitForSeconds(0.1f);
        for(int i=0;i<collider.Length;i++)
            collider[i].enabled = enable;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position,
            new Vector3(shadowRange * 2f * transform.localScale.x
            , 1.7f, 7.3f));
    }
}
