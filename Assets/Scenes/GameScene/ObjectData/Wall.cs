﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject WallPrefab;

    public ObjectsData WallData;

    private GameObject t;

    public void SpawnFront()
    {
        //! CloneInstance
        t = Instantiate(WallPrefab, WallData.spawnPoints[1], WallData.q) as GameObject;

        //! animation
        iTween.MoveBy(t, iTween.Hash("y", WallData.OInitAnim[1].y, "time", 1f, "delay", 3f));
    }

    public void SpawnBack()
    {
        //! CloneInstance
        t = Instantiate(WallPrefab, WallData.spawnPoints[1], WallData.q) as GameObject;

        //! animation
        iTween.MoveBy(t, iTween.Hash("y", WallData.OInitAnim[1].y, "time", 1f, "delay", 3f));
    }

    public void Delete()
    {
        iTween.MoveBy(t, iTween.Hash("y", WallData.ODereteAnim[1].y, "time", 1f, "delay", 1f));
        Destroy(t);
    }
}