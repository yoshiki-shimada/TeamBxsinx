using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLane : MonoBehaviour
{
    public GameObject LanePrefab;

    public ObjectsData LaneData;

    private GameObject t;

    public void Spawn()
    {
        //! CloneInstance
        t = Instantiate(LanePrefab, LaneData.spawnPoints[4], LaneData.q) as GameObject;

        //! animation
        iTween.MoveBy(t, iTween.Hash("x", LaneData.OInitAnim[0].x, "time", 2f,"delay",2f));
    }

    public void Delete()
    {
        iTween.MoveBy(t, iTween.Hash("x", LaneData.ODereteAnim[0].x, "time", 2f, "delay", 1f));

        Destroy(t);
    }
}
