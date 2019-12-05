using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MoveWall : MonoBehaviour
{
    private PlayableDirector playableDirector;

    public GameObject MWallPrefab;

    public ObjectsData MWallData;

    private GameObject t;

    public void SpawnFront()
    {
        //! CloneInstance
        t = Instantiate(MWallPrefab, MWallData.spawnPoints[2], MWallData.q) as GameObject;

        //! animation
        iTween.MoveBy(t, iTween.Hash("y", MWallData.OInitAnim[2].y, "time", 1f, "delay", 3f));
    }

    public void SpawnBack()
    {
        //! CloneInstance
        t = Instantiate(MWallPrefab, MWallData.spawnPoints[2], MWallData.q) as GameObject;

        //! animation
        iTween.MoveBy(t, iTween.Hash("y", MWallData.OInitAnim[2].y, "time", 1f, "delay", 3f));
    }

    public void Move()
    {
        playableDirector.Play();
    }
}
