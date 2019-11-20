using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum OverPhase : short
{
    OVERPHASE_INIT = 0x00,
    OVERPHASE_FADEIN = 0x01,
    OVERPHASE_RUN = 0x02,
    OVERPHASE_FADEOUT = 0x03,
    OVERPHASE_DONE = 0x04
}

public class Scenemanager : MonoBehaviour
{
    [SerializeField]
    private OverPhase m_ePhase;

    [SerializeField]
    float m_fFadeSpeed;

    public GameObject m_FadeObject;

    FadeManager m_Fade;

    string sNext;

    // Start is called before the first frame update
    void Start()
    {
        if (m_FadeObject)
            m_Fade = m_FadeObject.GetComponent<FadeManager>();
        m_fFadeSpeed = 0.005f;

        m_ePhase = OverPhase.OVERPHASE_INIT;
    }

    // Update is called once per frame
    void Update()
    {
        bool bFlag = false;

        switch (m_ePhase)
        {
            case OverPhase.OVERPHASE_INIT:

                m_ePhase = OverPhase.OVERPHASE_FADEIN;
                break;
            case OverPhase.OVERPHASE_FADEIN:

                bFlag = m_Fade.isFadeIn(m_fFadeSpeed);
                if (bFlag)
                    m_ePhase = OverPhase.OVERPHASE_RUN;
                break;
            case OverPhase.OVERPHASE_RUN:

                if (Input.GetButtonDown("GamePad1_buttonB"))
                    m_ePhase = OverPhase.OVERPHASE_FADEOUT;

                break;
            case OverPhase.OVERPHASE_FADEOUT:

                bFlag = m_Fade.isFadeOut(m_fFadeSpeed);
                if (bFlag)
                    m_ePhase = OverPhase.OVERPHASE_DONE;
                break;
            case OverPhase.OVERPHASE_DONE:

                SceneManager.LoadScene(sNext);
                break;
        }
    }

    public void StringArgFunction(string s)
    {
        sNext = s;
    }

}
