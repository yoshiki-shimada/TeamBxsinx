using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAction : MonoBehaviour
{
    public GameObject TextObject;
    public GameObject Chara;
    public GameObject IKON;
    public GameObject Text;

    public bool bFlag;

    [SerializeField]
    private float r, g, b;

    [SerializeField]
    private float m_fAlpha;

    // Start is called before the first frame update
    void Start()
    {
        bFlag = false;
        IKON.GetComponent<Image>().color = new Color(r, g, b, m_fAlpha);
        m_fAlpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 TextPos = TextObject.transform.position;
        Vector3 CharaPos = Chara.transform.position;
        float fDistance = Vector3.Distance(TextPos, CharaPos);


        if (fDistance <= 3.0f)
        {
            bFlag = true;
            m_fAlpha = 1.0f;
            Debug.Log("tuiteru");
        }
        else
        {
            bFlag = false;
            m_fAlpha = 0.0f;
            Debug.Log("nai");
        }

        IKON.GetComponent<Image>().color = new Color(r, g, b, m_fAlpha);

        if (bFlag == true && Input.GetButtonDown("GamePad1_buttonA"))
        {
            Debug.Log("SuccessofbuttonA");
            Text.GetComponent<TextDraw>().NextText();
            //Text.GetComponent<TextDraw>().DrawText();
        }

    }
}
