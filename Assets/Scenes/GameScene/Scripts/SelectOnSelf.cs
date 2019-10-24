using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectOnSelf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Selectable sel = GetComponent<Selectable>();
        sel.Select();
    }
}
