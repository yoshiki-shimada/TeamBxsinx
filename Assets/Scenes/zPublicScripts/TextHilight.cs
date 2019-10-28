using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextHilight : MonoBehaviour
{
    private float num = Mathf.PI;

    private void Update()
    {
        //! TextMeshProの機能を使うために前者のGUIをオブジェクトからとってくる
        TextMeshProUGUI tmPro = gameObject.GetComponent<TextMeshProUGUI>();
        Material material = tmPro.fontMaterial;

        /*
        * OutlineのThicknessの数値を変化
        * 三角関数のsinを使用
        * 絶対値を設定し負の値にならないようにする
        */
        material.SetFloat("_OutlineWidth", Mathf.Abs(Mathf.Sin(num)) * 2 / 5);
        num += Time.deltaTime * 2;
    }
}
