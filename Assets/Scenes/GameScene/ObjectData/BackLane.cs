using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLane : MonoBehaviour
{
    public GameObject LanePrefab;

    public ObjectsData LaneData;

    private GameObject t;
    private int Count;

    private void Start()
    {
        Count = 0;
    }

    public void Spawn()
    {
        //! CloneInstance
        t = Instantiate(LanePrefab, LaneData.spawnPoints[Count], LaneData.q) as GameObject;

        //! animation
        iTween.MoveBy(t, iTween.Hash("x", LaneData.OInitAnim[0].x, "time", 2f,"delay",2f));

        Count++;
    }

    public void Move()
    {
        iTween.MoveBy(t, iTween.Hash("x", LaneData.ODereteAnim[0].x, "time", 2f));
    }

    public void Delete()
    {
        Destroy(t);
    }
}
