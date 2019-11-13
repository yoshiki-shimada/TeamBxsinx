using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maruo : MonoBehaviour
{
    public GameObject MaruoPrefab;

    public ObjectsData ShadowObjectData;

    public void Spawn()
    {
        //! CloneInstance
        GameObject t = Instantiate(MaruoPrefab, ShadowObjectData.spawnPoints[0], ShadowObjectData.q) as GameObject;

        //! animation
        iTween.MoveBy(t, iTween.Hash("x", ShadowObjectData.OInitAnim[0].x, "time", 1f));
    }
}
