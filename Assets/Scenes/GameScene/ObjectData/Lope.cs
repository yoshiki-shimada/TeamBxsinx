﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lope : MonoBehaviour
{
    public GameObject LopePrefab;

    public ObjectsData LopeData;

    public void Spawn()
    {
        Debug.Log("adjkahgkjdshgkhsad");
        //! CloneInstance
        GameObject t = Instantiate(LopePrefab, LopeData.spawnPoints[0], LopeData.q) as GameObject;

        //! animation
        iTween.MoveBy(t, iTween.Hash("y", LopeData.OInitAnim[0].y, "time", 1f));
    }
}
