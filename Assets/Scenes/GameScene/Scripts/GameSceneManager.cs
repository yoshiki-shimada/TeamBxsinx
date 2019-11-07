﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GamePhase : short
{
    GAMEPHASE_INIT = 0x00,
    GAMEPHASE_FADEIN = 0x01,
    GAMEPHASE_STAGE1 = 0x02,
    GAMEPHASE_STAGE2 = 0x03,
    GAMEPHASE_STAGE3 = 0x04,
    GAMEPHASE_STAGE4 = 0x05,
    GAMEPHASE_FADEOUT = 0X06,
    GAMEPHASE_DONE = 0x07
}

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    private GamePhase m_ePhase;

    [SerializeField]
    float m_fFadeSpeed;

    FadeManager m_fFlag;

    public bool m_bStageFlag;

    int nPageCount;

    //ObjectInstantiate m_Instantiate;
    GameObject Tree1;
    GameObject Tree2;

    // Start is called before the first frame update
    void Start()
    {
        m_fFadeSpeed = 0.005f;
        m_bStageFlag = false;
        nPageCount = 0;
        Tree1 = GameObject.Find("Tree1");
        Tree2 = GameObject.Find("Tree2");

        m_ePhase = GamePhase.GAMEPHASE_INIT;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_ePhase)
        {
            case GamePhase.GAMEPHASE_INIT:
                m_ePhase = GamePhase.GAMEPHASE_FADEIN;
                break;
            case GamePhase.GAMEPHASE_FADEIN:
                m_ePhase = GamePhase.GAMEPHASE_STAGE1;
                break;
            case GamePhase.GAMEPHASE_STAGE1:
                if (nPageCount == 0)
                {
                    nPageCount++;
                    Tree1.GetComponent<Tree1>().Spawn();
                    Tree2.GetComponent<Tree2>().Spawn();
                    //Destroy(Tree1);
                }
                if (nPageCount == 2)
                    m_ePhase = GamePhase.GAMEPHASE_FADEOUT;
                break;
            case GamePhase.GAMEPHASE_FADEOUT:
                m_ePhase = GamePhase.GAMEPHASE_DONE;
                break;
            case GamePhase.GAMEPHASE_DONE:

                break;
        }
    }
}