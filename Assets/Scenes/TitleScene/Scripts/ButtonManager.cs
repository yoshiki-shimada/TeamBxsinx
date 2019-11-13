using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 自分を選択状態にする
        Selectable sel = GetComponent<Selectable>();
        sel.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
