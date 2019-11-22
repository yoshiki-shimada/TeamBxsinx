using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maruo : MonoBehaviour
{
    public GameObject MaruoPrefab;

    public GameObject LightManager;

    public ObjectsData ShadowObjectData;

    public void Spawn()
    {
        Debug.Log("adjkahgkjdshgkhsad");
        //! CloneInstance
        GameObject t = Instantiate(MaruoPrefab, ShadowObjectData.spawnPoints[0], ShadowObjectData.q2) as GameObject;

        LightManager.GetComponent<LightManager>().GetCenterObj();

        //! animation
        iTween.MoveBy(t, iTween.Hash("x", ShadowObjectData.OInitAnim[0].x, "time", 1f, "delay", 3f));
    }
}
