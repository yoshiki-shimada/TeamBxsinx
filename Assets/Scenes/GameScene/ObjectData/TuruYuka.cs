using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuruYuka : MonoBehaviour
{
    public GameObject TUPrefab;

    public ObjectsData TUData;

    private GameObject t;

    public void SpawnFront()
    {
        //! CloneInstance
        t = Instantiate(TUPrefab, TUData.spawnPoints[2], TUData.q2) as GameObject;

        //! animation
        iTween.MoveBy(t, iTween.Hash("x", TUData.OInitAnim[1].x, "time", 1f, "delay", 2.5f));
    }

    public void SpawnBack()
    {
        //! CloneInstance
        t = Instantiate(TUPrefab, TUData.spawnPoints[5], TUData.q2) as GameObject;

        //! animation
        iTween.MoveBy(t, iTween.Hash("y", TUData.OInitAnim[5].y, "time", 1f, "delay", 2.5f));
    }

    public void Delete()
    {
        iTween.MoveBy(t, iTween.Hash("x", TUData.ODereteAnim[1].x, "time", 1f, "delay", 1f));
        Destroy(t);
    }
}
