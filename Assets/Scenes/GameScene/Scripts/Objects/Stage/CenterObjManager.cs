﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterObjManager : MonoBehaviour
{

    public void UpdateAllRange()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<ShadowRange>().GetRange();
        }
    }
}
