using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree1 : MonoBehaviour
{
    //! Instance
    public GameObject Tree1Prefab;

    //! ObjectData
    public ObjectsData Tree1Data;

    public void Spawn()
    {
        Debug.Log("Tree1Init");

        //! CloneInstance
        GameObject t = Instantiate(Tree1Prefab, Tree1Data.spawnPoints[0],Tree1Data.q) as GameObject;
        
        //! animation
        iTween.MoveAdd(t, iTween.Hash("y",Tree1Data.OInitAnim[0].y,"time",2f));
        iTween.MoveAdd(t, iTween.Hash("x", Tree1Data.OInitAnim[1].x, "time", 1f, "delay", 2f));
        iTween.MoveAdd(t, iTween.Hash("y", Tree1Data.OInitAnim[2].y, "time", 1f, "delay", 4.5f));
    }
}

