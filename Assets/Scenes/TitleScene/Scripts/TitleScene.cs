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

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    private TitlePhase m_ePhase;

    [SerializeField]
    float m_fFadeSpeed;

    public GameObject m_FadeObject;

    FadeManager m_Fade;

    private float hori;

    int nCarsor;

    // Start is called before the first frame update
    void Start()
    {
        if (m_FadeObject)
            m_Fade = m_FadeObject.GetComponent<FadeManager>();
        m_fFadeSpeed = 0.005f;

        m_ePhase = TitlePhase.TITLEPHASE_INIT;
        nCarsor = 1;
    }

    // Update is called once per frame
    void Update()
    {
        bool bFlag = false;
        hori = Input.GetAxisRaw("GamePad1_LeftStick_H");

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


                if ((hori != 0))
                {
                    Debug.Log("o");
                    if (hori < -0.5f)
                        nCarsor--;

                    if (hori > 0.5f)
                        nCarsor--;

                    if (nCarsor < 0)
                        nCarsor = 2;

                    if (nCarsor > 2)
                        nCarsor = 0;
                }

                if (Input.GetButtonDown("GamePad1_buttonB"))
                    m_ePhase = TitlePhase.TITLEPHASE_FADEOUT;

                break;
            case TitlePhase.TITLEPHASE_FADEOUT:

                bFlag = m_Fade.isFadeOut(m_fFadeSpeed);
                if (bFlag)
                    m_ePhase = TitlePhase.TITLEPHASE_DONE;
                break;
            case TitlePhase.TITLEPHASE_DONE:

                SceneManager.LoadScene("MainScene");

                if (nCarsor == 0)
                    SceneManager.LoadScene("yoshiki");
                else if (nCarsor == 1)
                    SceneManager.LoadScene("MainScene");
                else
                    SceneManager.LoadScene("yoshiki");

                break;

        }
    }
}

