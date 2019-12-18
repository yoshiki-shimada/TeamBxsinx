using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatInManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] CatInPrefab;

    [SerializeField]
    GameObject canvas;

    [SerializeField]
    PlayerHP FHP;
    [SerializeField]
    PlayerHP BHP;
    [SerializeField]
    Image CatInIkon;

    private GameObject CreentCatIn;

    float r, g, b, m_fAlpha, fSpeed;
    int i, iPhase;
    bool InFlag;
    //! 連打防止
    private bool b_Flag;

    // Start is called before the first frame update
    void Start()
    {
        b_Flag = false;
        i = 0;
        InFlag = true;
        CreentCatIn = (GameObject)Instantiate(CatInPrefab[i]);
        m_fAlpha = 0.0f;
        iPhase = 0;
        fSpeed = 0.05f;
    }

    private void Update()
    {
        if (b_Flag)
        {
            switch (iPhase)
            {
                case 0:
                    if (m_fAlpha < 1.0f)
                        m_fAlpha += fSpeed;
                    else
                        iPhase = 1;
                    break;
                case 1:
                    if (m_fAlpha > 0.0f)
                        m_fAlpha -= fSpeed;
                    else
                        iPhase = 0;
                    break;
            }
            if (CatInIkon)
            {
                CatInIkon.color = new Color(1, 1, 1, m_fAlpha);
            }
        }
    }

    // Update is called once per frame
    public bool isCatIn()
    {
        if (InFlag)
        {
            FHP.MoveHPLight(-2f);
            BHP.MoveHPLight(-2f);
            CreentCatIn.transform.SetParent(canvas.transform, false);
            iTween.MoveAdd(CreentCatIn, iTween.Hash("y", -21, "time", 2.0f, "oncomplete", "OncompleteHandler", "oncompletetarget", gameObject));
            InFlag = false;
        }

        if (b_Flag && Input.GetButtonDown("GamePad1_buttonA"))
        {
            b_Flag = false;
            CatInIkon.color = new Color(1, 1, 1, 0);
            FHP.MoveHPLight(0f);
            BHP.MoveHPLight(0f);
            iTween.MoveAdd(CreentCatIn, iTween.Hash("y", -80f, "time", 10.0f, "oncomplete", "NextCat", "oncompletetarget", CreentCatIn));
            i++;
            InFlag = true;
            CreentCatIn = (GameObject)Instantiate(CatInPrefab[i]);

            foreach (Transform child in canvas.transform)
                Destroy(child.gameObject);

            return true;
        }
        return false;
    }

    void OncompleteHandler()
    {
        Debug.Log("OncompleteHandler");
        b_Flag = true;
    }
}