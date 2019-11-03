using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GamePhase : short
{
    GAMEPHASE_INIT = 0x00,
    GAMEPHASE_FADEIN = 0x01,
    GAMEPHASE_RUN = 0x02,
    GAMEPHASE_FADEOUT = 0X03,
    GAMEPHASE_DONE = 0x04
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

    // Start is called before the first frame update
    void Start()
    {
        m_fFadeSpeed = 0.005f;
        m_bStageFlag = false;
        nPageCount = 0;
        Tree1 = GameObject.Find("Tree1");

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
                m_ePhase = GamePhase.GAMEPHASE_RUN;
                break;
            case GamePhase.GAMEPHASE_RUN:
                if (m_bStageFlag)
                {
                    nPageCount++;
                    m_bStageFlag = false;
                   // m_Instantiate.NextPage(nPageCount);
                }
                if (nPageCount == 2)
                    m_ePhase = GamePhase.GAMEPHASE_FADEOUT;
                Tree1.GetComponent<Tree1>().Spawn();
                break;
            case GamePhase.GAMEPHASE_FADEOUT:
                m_ePhase = GamePhase.GAMEPHASE_DONE;
                break;
            case GamePhase.GAMEPHASE_DONE:

                break;
        }
    }
}
