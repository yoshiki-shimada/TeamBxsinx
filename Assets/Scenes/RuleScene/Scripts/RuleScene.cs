using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum RulePhase : short
{
    RULEPHASE_INIT = 0x00,
    RULEPHASE_FADEIN = 0x01,
    RULEPHASE_RUN = 0x02,
    RULEPHASE_FADEOUT = 0x03,
    RULEPHASE_DONE = 0x04
}

public class RuleScene : MonoBehaviour
{
    [SerializeField]
    private RulePhase m_ePhase;

    [SerializeField]
    float m_fFadeSpeed;

    public GameObject m_FadeObject;

    FadeManager m_Fade;

    // Use this for initialization
    void Start()
    {
        if (m_FadeObject)
            m_Fade = m_FadeObject.GetComponent<FadeManager>();

        m_ePhase = RulePhase.RULEPHASE_INIT;
    }

    // Update is called once per frame
    void Update()
    {
        bool bFlag = false;

        switch (m_ePhase)
        {
            case RulePhase.RULEPHASE_INIT:

                m_ePhase = RulePhase.RULEPHASE_FADEIN;
                break;
            case RulePhase.RULEPHASE_FADEIN:

                bFlag = m_Fade.isFadeIn(m_fFadeSpeed);
                if (bFlag)
                    m_ePhase = RulePhase.RULEPHASE_RUN;
                break;
            case RulePhase.RULEPHASE_RUN:

                if (Input.GetButtonDown("GamePad1_buttonB"))
                    m_ePhase = RulePhase.RULEPHASE_FADEOUT;

                break;
            case RulePhase.RULEPHASE_FADEOUT:

                bFlag = m_Fade.isFadeOut(m_fFadeSpeed);
                if (bFlag)
                    m_ePhase = RulePhase.RULEPHASE_DONE;
                break;
            case RulePhase.RULEPHASE_DONE:

                SceneManager.LoadScene("TitleScene");
                break;
        }
    }
}