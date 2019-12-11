using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public GameObject MWallPrefab;

    public ObjectsData MWallData;

    private GameObject t;

    public void SpawnFront()
    {
        //! CloneInstance
        t = Instantiate(MWallPrefab, MWallData.spawnPoints[3], MWallData.q2) as GameObject;

        //! animation
        iTween.MoveBy(t, iTween.Hash("y", MWallData.OInitAnim[3].y, "time", 1f, "delay", 2.5f));
    }

    public void SpawnBack()
    {
        //! CloneInstance
        t = Instantiate(MWallPrefab, MWallData.spawnPoints[2], MWallData.q2) as GameObject;

        //! animation
        iTween.MoveBy(t, iTween.Hash("y", MWallData.OInitAnim[2].y, "time", 1f, "delay", 2.5f));
    }

    public void Delete()
    {
        iTween.MoveBy(t, iTween.Hash("x", MWallData.ODereteAnim[2].y, "time", 1f, "delay", 1f));
        Destroy(t);
    }
}
