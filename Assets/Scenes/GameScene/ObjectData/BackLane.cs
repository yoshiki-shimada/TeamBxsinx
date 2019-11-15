using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLane : MonoBehaviour
{
    public GameObject LanePrefab;

    public ObjectsData LaneData;

    public void Spawn()
    {
        Debug.Log("adjkahgkjdshgkhsad");
        //! CloneInstance
        GameObject t = Instantiate(LanePrefab, LaneData.spawnPoints[4], LaneData.q) as GameObject;

        //! animation
        iTween.MoveBy(t, iTween.Hash("x", LaneData.OInitAnim[2].x, "time", 2f,"delay",2f));
    }
}
