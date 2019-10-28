using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHeight : MonoBehaviour
{
    //! 現在のボタン
    private GameObject Button;

    //! ひとつ前
    private GameObject ButtonBuf;

    //! エフェクト　後程
    private int i = 0;

    // Update is called once per frame
    void Update()
    {
        //! 現在選択されているボタンを取得し、Buttonに代入
        Button = EventSystem.current.currentSelectedGameObject;

        if (i == 0)
        {
            ButtonBuf = Button;
            i++;
        }

        if (Button != ButtonBuf)
        {
            int j = 0;
            /*
             * 選択中のボタンの子要素を取得(1番目の要素は文字なので飛ばす)
             */
            foreach (Transform child in Button.transform)
            {
                //ButtonEffect[j] = child.gameObject;
                //if (j > 0) ButtonEffect[j].SetActive(true);
                //j++;
            }
            //ButtonEffect[0].GetComponent<TextHighlight>().enabled = true;
            j = 0;
            /*
             * 一つ前にに選択していたボタンの子要素を取得(1番目の要素は文字なので飛ばす)
             */
            foreach (Transform child in ButtonBuf.transform)
            {
                //  ButtonEffect[j] = child.gameObject;
                //if (j > 0) ButtonEffect[j].SetActive(false);
                j++;
            }

            //! カーソルを動かしたとき点滅するボタンを変える
            if (Button != ButtonBuf)
            {
                //int j = 0;

            }

            ButtonBuf = Button;
        }
    }

}