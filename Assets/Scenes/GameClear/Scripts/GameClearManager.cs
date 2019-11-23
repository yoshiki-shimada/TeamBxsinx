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
    GameObject[] Imeeeeji;

    [SerializeField]
    GameObject canvas;

    GameObject Image;
    GameObject FrontImage;
    int i,m;
    bool bImageFlag;

    // Start is called before the first frame update
    void Start()
    {
        FrontImage = (GameObject)Instantiate(Imeeeeji[0]);
        i = 0;
        m = Imeeeeji.Length;
        //ImageChange();
        bImageFlag = false;

        //! フェードオブジェクト
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

                if (Input.GetButtonDown("GamePad1_buttonB") && !bImageFlag)
                {
                    bImageFlag = true;
                }
                if (bImageFlag)
                {
                    //FrontImage = Image;
                    i++;
                    if (i > m)
                    {
                        m_ePhase = ClearPhase.CLEARPHASE_FADEOUT;
                        break;
                    }
                    ImageChange();
                    bImageFlag = false;
                    iTween.MoveAdd(FrontImage, iTween.Hash("x", -1920f, "time", 10.0f));
                }
            
                break;
            case ClearPhase.CLEARPHASE_FADEOUT:

                m_FadeObject.GetComponent<RectTransform>().SetAsLastSibling();
                bFlag = m_Fade.isFadeOut(m_fFadeSpeed);
                if (bFlag)
                    m_ePhase = ClearPhase.CLEARPHASE_DONE;
                break;
            case ClearPhase.CLEARPHASE_DONE:

                SceneManager.LoadScene("TitleScene");
                break;
        }
    }

    private void ImageChange()
    {
        Debug.Log("ahfeh;gaed");
        Image = (GameObject)Instantiate(Imeeeeji[i]);
        Image.transform.SetParent(canvas.transform, false);
        FrontImage = (GameObject)Instantiate(Imeeeeji[i - 1]);
        FrontImage.transform.SetParent(canvas.transform, false);
        //yield return new WaitForSeconds(10f);
    }
}
