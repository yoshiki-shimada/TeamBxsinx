using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum OverPhase : short
{
    OVERPHASE_INIT = 0x00,
    OVERPHASE_FADEIN = 0x01,
    OVERPHASE_RUN = 0x02,
    OVERPHASE_FADEOUT = 0x03,
    OVERPHASE_DONE = 0x04
}

enum SelectButton : short
{
    SELECT_CONTENUE = 0x00,
    SELECT_RETURNTITLE = 0x01
}

public class Scenemanager : MonoBehaviour
{
    [SerializeField]
    private OverPhase m_ePhase;

    [SerializeField]
    float m_fFadeSpeed;

    [SerializeField]
    private SelectButton m_eSelect;

    [SerializeField]
    private Image Contenue;
    [SerializeField]
    private Image Title;

    GameObject SoundObj;

    public GameObject m_FadeObject;

    FadeManager m_Fade;

    //! 連続入力防止用フラグ
    private bool m_bFlag;

    string sNext;

    // Start is called before the first frame update
    void Start()
    {
        if (m_FadeObject)
            m_Fade = m_FadeObject.GetComponent<FadeManager>();

        m_eSelect = SelectButton.SELECT_CONTENUE;
        m_ePhase = OverPhase.OVERPHASE_INIT;
        m_bFlag = false;
        SoundObj = GameObject.Find("SoundManager");
        SoundObj.GetComponent<SoundManager>().State();
    }

    // Update is called once per frame
    void Update()
    {
        bool bFlag = false;
        float hori = Input.GetAxisRaw("GamePad1_LeftStick_H");

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

                if (!m_bFlag)
                {
                    switch (m_eSelect)
                    {
                        case SelectButton.SELECT_CONTENUE:

                            Title.GetComponent<TextHilight>().None();
                            Contenue.GetComponent<TextHilight>().Flash();
                            if (hori < -0.5f || hori > 0.5f)
                            {
                                m_eSelect = SelectButton.SELECT_RETURNTITLE;
                                m_bFlag = true;
                            }
                            break;
                        case SelectButton.SELECT_RETURNTITLE:

                            Contenue.GetComponent<TextHilight>().None();
                            Title.GetComponent<TextHilight>().Flash();
                            if (hori < -0.5f || hori > 0.5f)
                            {
                                m_eSelect = SelectButton.SELECT_CONTENUE;
                                m_bFlag = true;
                            }
                            break;
                    }
                }
                else
                {
                    if (hori < 0.5f && hori > -0.5f)
                        m_bFlag = false;
                }
                if (Input.GetButtonDown("GamePad1_buttonB"))
                    m_ePhase = OverPhase.OVERPHASE_FADEOUT;

                break;
            case OverPhase.OVERPHASE_FADEOUT:

                bFlag = m_Fade.isFadeOut(m_fFadeSpeed);
                if (bFlag)
                    m_ePhase = OverPhase.OVERPHASE_DONE;
                break;
            case OverPhase.OVERPHASE_DONE:

                switch (m_eSelect)
                {
                    case SelectButton.SELECT_CONTENUE:

                        SceneManager.LoadScene("MainScene");
                        break;
                    case SelectButton.SELECT_RETURNTITLE:

                        SceneManager.LoadScene("TitleScene");
                        break;
                }
                SceneManager.LoadScene(sNext);
                break;
        }
    }
}
