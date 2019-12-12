using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lope : MonoBehaviour
{
    public GameObject LopePrefab;

    public ObjectsData LopeData;

    private GameObject t;

    public void SpawnFront()
    {
        Debug.Log("adjkahgkjdshgkhsad");
        //! CloneInstance
        t = Instantiate(LopePrefab, LopeData.spawnPoints[4], LopeData.q2) as GameObject;

        //! Set DesIndex
        t.GetComponent<Goal>().Desindex = 0;

        //! animation
        iTween.MoveBy(t, iTween.Hash("y", LopeData.OInitAnim[4].y, "time", 1f,"delay",2f));
    }

    public void SpawnBack()
    {
        Debug.Log("adjkahgkjdshgkhsad");
        //! CloneInstance
        t = Instantiate(LopePrefab, LopeData.spawnPoints[0], LopeData.q2) as GameObject;

        //! Set DesIndex
        t.GetComponent<Goal>().Desindex = 1;

        //! animation
        iTween.MoveBy(t, iTween.Hash("y", LopeData.OInitAnim[0].y, "time", 1f, "delay", 3f));
    }

    public void Move()
    {
        
    }

    public void Delete()
    {
        iTween.MoveBy(t, iTween.Hash("y", LopeData.ODereteAnim[0].y, "time", 1f, "delay", 1f));
        Destroy(t);
    }
}
