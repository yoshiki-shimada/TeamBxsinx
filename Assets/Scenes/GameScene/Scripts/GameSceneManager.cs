using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject Objectugokuze;

    // Start is called before the first frame update
    void Start()
    {
        m_fFadeSpeed = 0.005f;
        m_bStageFlag = false;
        nPageCount = 0;

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
                    Objectugokuze.GetComponent<MoveObjects>().Stage1();
                    //Destroy(Maruo);
                }
                if (m_bStageFlag)
                {
                    m_ePhase = GamePhase.GAMEPHASE_FADEOUT;
                    Debug.Log("やっぱり俺最強");
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
