using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDraw : MonoBehaviour
{
    //! 文章格納用
    public string[] Sentences;

    [SerializeField]
    Text uiText;

    //! 一文字表示で使う時間
    [SerializeField]
    [Range(0.001f, 0.3f)]
    float intervalForCharDisplay = 0.05f;

    private int displayNum = 0;                     //  現在の表示文字の番号
    public string stringdisplay = string.Empty;    //  現在の文字列
    private float timeUntilDisplay = 0;             //  表示にかかる時間
    private float timeBeganDisplay = 1;             //  文字列の表示を始めた時間
    private int lastUpdateCharCount = -1;           //  表示中の文字数

    // Start is called before the first frame update
    public void NextText()
    {
        SetNextSentence();
    }

    // Update is called once per frame
    void Update()
    {
        if (displayNum < Sentences.Length)
        {
            Debug.Log("InDrawText");

            // CrearFlagがたったら
            //　Textを消す
            //  テキストにAlphaがあるならそれをいじる
            //  ないならImageで作る
            //  SetNextSentence();

            //表示される文字数を計算
            int displayCharCount = (int)(Mathf.Clamp01((Time.time - timeBeganDisplay) / timeUntilDisplay) * stringdisplay.Length);
            //表示される文字数が表示している文字数と違う
            if (displayCharCount != lastUpdateCharCount)
            {
                uiText.text = stringdisplay.Substring(0, displayCharCount);
                //表示している文字数の更新
                lastUpdateCharCount = displayCharCount;
            }
        }
    }

    // 次の文章をセットする
    void SetNextSentence()
    {
        stringdisplay = Sentences[displayNum];
        timeUntilDisplay = stringdisplay.Length * intervalForCharDisplay;
        timeBeganDisplay = Time.time;
        displayNum++;
        lastUpdateCharCount = 0;
    }

    bool IsDisplayComplete()
    {
        return Time.time > timeBeganDisplay + timeUntilDisplay;
    }
}

