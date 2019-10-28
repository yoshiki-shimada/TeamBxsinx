using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum TitlePhase : short
{
    TITLEPHASE_INIT = 0x00,
    TITLEPHASE_FADEIN = 0x01,
    TITLEPHASE_RUN = 0x02,
    TITLEPHASE_FADEOUT = 0x03,
    TITLEPHASE_DONE = 0x04
}

enum ButtonNum : short
{
    SCENE_RULE = 0x00,
    SCENE_MAIN = 0x01,
    SCENE_DONE = 0x02
}

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    private TitlePhase m_ePhase;

    [SerializeField]
    private ButtonNum B_Num;

    [SerializeField]
    float m_fFadeSpeed;

    public GameObject m_FadeObject;

    FadeManager m_Fade;

    // Start is called before the first frame update
    void Start()
    {
        if (m_FadeObject)
            m_Fade = m_FadeObject.GetComponent<FadeManager>();
        m_fFadeSpeed = 0.005f;

        m_ePhase = TitlePhase.TITLEPHASE_INIT;
        B_Num = ButtonNum.SCENE_MAIN;
    }

    // Update is called once per frame
    void Update()
    {
        bool bFlag = false;

        switch (m_ePhase)
        {
            case TitlePhase.TITLEPHASE_INIT:

                m_ePhase = TitlePhase.TITLEPHASE_FADEIN;
                break;
            case TitlePhase.TITLEPHASE_FADEIN:

                bFlag = m_Fade.isFadeIn(m_fFadeSpeed);
                if (bFlag)
                    m_ePhase = TitlePhase.TITLEPHASE_RUN;
                break;
            case TitlePhase.TITLEPHASE_RUN:
                
                if (Input.GetButtonDown("GamePad1_buttonB"))
                {

                    m_ePhase = TitlePhase.TITLEPHASE_FADEOUT;
                }
                break;
            case TitlePhase.TITLEPHASE_FADEOUT:

                bFlag = m_Fade.isFadeOut(m_fFadeSpeed);
                if (bFlag)
                    m_ePhase = TitlePhase.TITLEPHASE_DONE;
                break;
            case TitlePhase.TITLEPHASE_DONE:

                if (B_Num == ButtonNum.SCENE_RULE)
                    SceneManager.LoadScene("yoshiki");
                else if (B_Num == ButtonNum.SCENE_MAIN)
                    SceneManager.LoadScene("MainScene");
                else
                    SceneManager.LoadScene("yoshiki");

                break;

        }
    }
}

