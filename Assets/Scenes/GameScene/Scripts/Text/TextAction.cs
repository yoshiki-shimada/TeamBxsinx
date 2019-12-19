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

    private RectTransform TextImage;
    public float x, y;

    public bool bFlag;

    [SerializeField]
    private float r, g, b;

    [SerializeField]
    private float m_fAlpha;

    public bool TextFlag;

    // Start is called before the first frame update
    void Start()
    {
        bFlag = false;
        TextFlag = true;
        IKON.GetComponent<Image>().color = new Color(r, g, b, m_fAlpha);
        TextImage = GameObject.Find("TextImage").GetComponent<RectTransform>();
        m_fAlpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 TextPos = TextObject.transform.position;
        Vector3 CharaPos = Chara.transform.position;
        float fDistance = Vector3.Distance(TextPos, CharaPos);

        if (fDistance <= 3.5f)
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

        if (TextFlag && bFlag && Input.GetButtonDown("GamePad1_buttonA"))
        {
            Debug.Log("SuccessofbuttonA");
            TextFlag = false;
            //! Itweenで枠を移動

            //! ImageのWidthを広げる
            TextImage.sizeDelta = new Vector2(x, y);
            Text.GetComponent<TextDraw>().SetNextSentence();
        }

    }
}
