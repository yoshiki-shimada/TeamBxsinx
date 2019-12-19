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

    public void Init()
    {
        iTween.MoveBy(ButtonPrefab, iTween.Hash("z", 10, "time", 1f));
    }

    public void Delete()
    {
        iTween.MoveBy(ButtonPrefab, iTween.Hash("z", -10, "time", 1f));
    }
}
