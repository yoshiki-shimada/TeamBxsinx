using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum ClearPhase : short
{
    CLEARPHASE_INIT = 0x00,
    CLEARPHASE_FADEIN = 0x01,
    CLEARPHASE_RUN = 0x02,
    CLEARPHASE_FADEOUT = 0x03,
    CLEARPHASE_DONE = 0x04
}

public class GameClearManager : MonoBehaviour
{
    [SerializeField]
    private ClearPhase m_ePhase;

    [SerializeField]
    float m_fFadeSpeed;

    public GameObject m_FadeObject;

    FadeManager m_Fade;

    [SerializeField]
    GameObject Imeeeeji;

    [SerializeField]
    GameObject canvas;

    GameObject Image;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("NextImage");
        Image = (GameObject)Instantiate(Imeeeeji);

        if (m_FadeObject)
            m_Fade = m_FadeObject.GetComponent<FadeManager>();
        m_fFadeSpeed = 0.005f;

        m_ePhase = ClearPhase.CLEARPHASE_INIT;
    }

    // Update is called once per frame
    void Update()
    {
        bool bFlag = false;

        switch (m_ePhase)
        {
            case ClearPhase.CLEARPHASE_INIT:

                m_ePhase = ClearPhase.CLEARPHASE_FADEIN;
                break;
            case ClearPhase.CLEARPHASE_FADEIN:

                bFlag = m_Fade.isFadeIn(m_fFadeSpeed);
                if (bFlag)
                    m_ePhase = ClearPhase.CLEARPHASE_RUN;
                break;
            case ClearPhase.CLEARPHASE_RUN:

                StartCoroutine("NextImage");
                if (Input.GetButtonDown("GamePad1_buttonB")) ///////&&全てのImageを描画したか
                    m_ePhase = ClearPhase.CLEARPHASE_FADEOUT;
                break;
            case ClearPhase.CLEARPHASE_FADEOUT:

                bFlag = m_Fade.isFadeOut(m_fFadeSpeed);
                if (bFlag)
                    m_ePhase = ClearPhase.CLEARPHASE_DONE;
                break;
            case ClearPhase.CLEARPHASE_DONE:

                SceneManager.LoadScene("TitleScene");
                break;
        }
    }

    IEnumerator NextImage()
    {
        Debug.Log("ahfeh;gaed");
        Image.transform.SetParent(canvas.transform, false);
        yield return new WaitForSeconds(100f);
    }
}
