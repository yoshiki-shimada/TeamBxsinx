﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowRange : MonoBehaviour
{
    private Renderer plane;
    private MeshCollider collider;
    private SolidRange Solid;

    // 0:薄い影の範囲 1:3D影の範囲
    private float shadowRange = 1f;
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
    }

    // Update is called once per frame
    void Update()
    {
        if(collider.transform.localPosition.x<=shadowRange &&
            collider.transform.localPosition.x >= -shadowRange &&
            collider.transform.localPosition.y >= -1.5f)
        {
            NowMode = ShadowMode.Plane;
            if (PrevMode == ShadowMode.Nothing)
            {
                ChangeShadowPhase(0.7f, 0.4f,plane.gameObject);
            }else if (PrevMode == ShadowMode.Solid)
            {
                ChangeShadowPhase(0.7f, 0.3f, plane.gameObject);
                ChangeShadowPhase(0f, 0.3f, collider.gameObject);
                StartCoroutine(Shadow_enable(false));
            }
                
                
            if (Solid.CheckSolidRange(collider.transform.position))
            {
                NowMode = ShadowMode.Solid;
                if (PrevMode == ShadowMode.Plane)
                {
                    ChangeShadowPhase(0.7f, 0.3f, collider.gameObject);
                    ChangeShadowPhase(0f, 0.3f, collider.gameObject);
                    StartCoroutine(Shadow_enable(true));
                }

            }
                
        }
        else
        {
            NowMode = ShadowMode.Nothing;
            if (PrevMode == ShadowMode.Plane) {
                ChangeShadowPhase(0f, 0.4f,plane.gameObject);
            }
              
        }
        PrevMode = NowMode;
    }

    public void GetShadow()
    {
        collider = this.transform.GetChild(0).GetComponent<MeshCollider>();
        plane = collider.transform.GetChild(0).GetComponent<Renderer>();
        Solid = GameObject.FindGameObjectWithTag("Shadow3DRange")
            .GetComponent<SolidRange>();
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
        yield return new WaitForSeconds(0.3f);
        collider.enabled = enable;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position,
            new Vector3(shadowRange * 2f * transform.localScale.x
            , 1.56f, 7.3f));
    }
}