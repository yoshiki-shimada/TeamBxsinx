using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicObj : MonoBehaviour
{
    public GameObject MarutaPrefab;

    public ObjectsData MarutaData;

    private GameObject t;

    public void SpawnFront()
    {
        //! CloneInstance
        t = Instantiate(MarutaPrefab, MarutaData.spawnPoints[2], MarutaData.q2) as GameObject;

        //! animation
        iTween.MoveBy(t, iTween.Hash("x", MarutaData.OInitAnim[1].x, "time", 1f, "delay", 2.5f));
    }

    public void SpawnBack()
    {
        //! CloneInstance
        t = Instantiate(MarutaPrefab, MarutaData.spawnPoints[2], MarutaData.q2) as GameObject;

        //! animation
        iTween.MoveBy(t, iTween.Hash("x", MarutaData.OInitAnim[1].x, "time", 1f, "delay", 2.5f));
    }

    public void Delete()
    {
        iTween.MoveBy(t, iTween.Hash("x", MarutaData.ODereteAnim[1].x, "time", 1f, "delay", 1f));
        Destroy(t);
    }
}
