using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject ButtonPrefab;

    public ObjectsData ButtonData;

    private GameObject t;

    public void Spawn()
    {
        t = Instantiate(ButtonPrefab, ButtonData.spawnPoints[1], ButtonData.q) as GameObject;
        iTween.MoveBy(t, iTween.Hash("z",ButtonData.OInitAnim[0].x, "time", 1f));
    }

    public void Delete()
    {
        iTween.MoveBy(t, iTween.Hash("z", ButtonData.ODereteAnim[0].x, "time", 1f, "delay", 1f));
        Destroy(t);
    }
}
