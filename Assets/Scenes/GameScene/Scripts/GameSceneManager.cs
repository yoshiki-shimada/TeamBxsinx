using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum GamePhase : short
{
    GAMEPHASE_INIT = 0x00,
    GAMEPHASE_FADEIN = 0x01,
    GAMEPHASE_FORESTSTATE = 0x02,
    GAMEPHASE_TYUTO1 = 0x03,
    GAMEPHASE_TYUTO2 = 0x04,
    GAMEPHASE_TYUTO3 = 0x05,
    GAMEPHASE_STAGE1 = 0x06,
    GAMEPHASE_STAGE2 = 0x07,
    GAMEPHASE_STAGE3 = 0x08,
    GAMEPHASE_STAGE4 = 0x09,
    GAMEPHASE_FADEOUT = 0X10,
    GAMEPHASE_DONE = 0x11,
}

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    private GamePhase m_ePhase;

    [SerializeField]
    float m_fFadeSpeed;

    public GameObject m_FadeObject;
    public GameObject m_CatInObject;

    FadeManager m_fFade;
    CatInManager m_fCat;

    [SerializeField]
    PlayerManager m_fPlayer;

    public bool m_bStageFlag;
    public bool m_bMoveFlag;


    public GameObject Objectugokuze;

    int CatCount;

    // Start is called before the first frame update
    void Start()
    {
        if (m_FadeObject)
            m_fFade = m_FadeObject.GetComponent<FadeManager>();
        if (m_CatInObject)
            m_fCat = m_CatInObject.GetComponent<CatInManager>();
        m_bStageFlag = true;
        m_bMoveFlag = true;

        CatCount = 0;

        m_ePhase = GamePhase.GAMEPHASE_INIT;
    }

    // Update is called once per frame
    public void Update()
    {
        bool bFlag = false;
        bool bCatInFlag = false;
        switch (m_ePhase)
        {
            case GamePhase.GAMEPHASE_INIT:
                m_ePhase = GamePhase.GAMEPHASE_FADEIN;
                break;
            case GamePhase.GAMEPHASE_FADEIN:

                bFlag = m_fFade.isFadeIn(m_fFadeSpeed);
                if (bFlag)
                {
                    bCatInFlag = m_fCat.isCatIn();
                    if (bCatInFlag)
                    {
                        CatCount++;
                        bCatInFlag = false;
                        if (CatCount >= 2)
                        {
                            m_ePhase = GamePhase.GAMEPHASE_FORESTSTATE;
                            bCatInFlag = false;
                            break;
                        }
                    }
                }
                break;
            case GamePhase.GAMEPHASE_FORESTSTATE:

                bCatInFlag = m_fCat.isCatIn();
                if (bCatInFlag)
                {
                    m_ePhase = GamePhase.GAMEPHASE_TYUTO1;
                    Objectugokuze.GetComponent<MoveObjects>().One();
                    m_bStageFlag = false; bCatInFlag = false;
                }
                break;
            case GamePhase.GAMEPHASE_TYUTO1:
                if (m_bStageFlag)
                {
                    if (!m_bMoveFlag)
                    {
                        Objectugokuze.GetComponent<MoveObjects>().One();
                    }
                    bCatInFlag = m_fCat.isCatIn();
                    if (bCatInFlag)
                    {
                        m_fPlayer.ResetPlayer();
                        Objectugokuze.GetComponent<MoveObjects>().two();
                        m_bStageFlag = false; m_bMoveFlag = false; bCatInFlag = false;
                        m_ePhase = GamePhase.GAMEPHASE_TYUTO2;
                        break;
                    }
                }
                break;
            case GamePhase.GAMEPHASE_TYUTO2:
                if (m_bStageFlag)
                {
                    if (!m_bMoveFlag)
                    {
                        Objectugokuze.GetComponent<MoveObjects>().two();
                    }
                    bCatInFlag = m_fCat.isCatIn();
                    if (bCatInFlag)
                    {
                        m_fPlayer.ResetPlayer();
                        Objectugokuze.GetComponent<MoveObjects>().three();
                        m_bStageFlag = false; m_bMoveFlag = false; bCatInFlag = false;
                        m_ePhase = GamePhase.GAMEPHASE_TYUTO3;
                        break;
                    }
                }
                break;
            case GamePhase.GAMEPHASE_TYUTO3:
                if (m_bStageFlag)
                {
                    if (!m_bMoveFlag)
                    {
                        Objectugokuze.GetComponent<MoveObjects>().three();
                    }
                    bCatInFlag = m_fCat.isCatIn();
                    if (bCatInFlag)
                    {
                        m_fPlayer.ResetPlayer();
                        Objectugokuze.GetComponent<MoveObjects>().Stage1();
                        m_bStageFlag = false; m_bMoveFlag = false; bCatInFlag = false;
                        m_ePhase = GamePhase.GAMEPHASE_STAGE1;
                        break;
                    }
                }
                break;
            case GamePhase.GAMEPHASE_STAGE1:

                if (m_bStageFlag)
                {
                    if (!m_bMoveFlag)
                    {
                        Objectugokuze.GetComponent<MoveObjects>().Stage1();
                    }
                    bCatInFlag = m_fCat.isCatIn();
                    if (bCatInFlag)
                    {
                        m_fPlayer.ResetPlayer();
                        Objectugokuze.GetComponent<MoveObjects>().Stage2();
                        m_bStageFlag = false; m_bMoveFlag = false; bCatInFlag = false;
                        m_ePhase = GamePhase.GAMEPHASE_STAGE2;
                        break;
                    }
                }
                break;
            case GamePhase.GAMEPHASE_STAGE2:

                if (m_bStageFlag)
                {
                    if (!m_bMoveFlag)
                    {
                        Objectugokuze.GetComponent<MoveObjects>().Stage2();
                    }
                    bCatInFlag = m_fCat.isCatIn();
                    if (bCatInFlag)
                    {
                        m_fPlayer.ResetPlayer();
                        Objectugokuze.GetComponent<MoveObjects>().Stage3();
                        m_bStageFlag = false; m_bMoveFlag = false; bCatInFlag = false;
                        m_ePhase = GamePhase.GAMEPHASE_STAGE3;
                        break;
                    }
                }
                break;
            case GamePhase.GAMEPHASE_STAGE3:
                if (m_bStageFlag)
                {
                    if (!m_bMoveFlag)
                    {
                        Objectugokuze.GetComponent<MoveObjects>().Stage3();
                    }
                    bCatInFlag = m_fCat.isCatIn();
                    if (bCatInFlag)
                    {
                        m_fPlayer.ResetPlayer();
                        //Objectugokuze.GetComponent<MoveObjects>().Stage4();
                        m_bStageFlag = false; m_bMoveFlag = false; bCatInFlag = false;
                        m_ePhase = GamePhase.GAMEPHASE_STAGE3;
                        break;
                    }
                }
                break;
            case GamePhase.GAMEPHASE_FADEOUT:
                Debug.Log("やっぱり俺最強");
                m_ePhase = GamePhase.GAMEPHASE_DONE;
                break;
            case GamePhase.GAMEPHASE_DONE:

                SceneManager.LoadScene("GameClear");
                break;
        }
    }
}
