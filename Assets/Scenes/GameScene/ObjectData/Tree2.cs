using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree2 : MonoBehaviour
{
    public GameObject Tree2Prefab;

    public ObjectsData Tree2Data;

    public void Spawn()
    {
        //! CloneInstance
        GameObject t = Instantiate(Tree2Prefab, Tree2Data.spawnPoints[1], Tree2Data.q) as GameObject;

        //! animation
        iTween.MoveBy(t, iTween.Hash("y", Tree2Data.OInitAnim[0].y, "time", 2f,"delay",1f));
        iTween.MoveAdd(t, iTween.Hash("x", Tree2Data.OInitAnim[1].x, "time", 1f, "delay", 2f));
        iTween.MoveAdd(t, iTween.Hash("y", Tree2Data.OInitAnim[2].y, "time", 1f, "delay", 3f));
    }
}
