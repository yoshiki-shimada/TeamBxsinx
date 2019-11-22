using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    //ObjectInstantiate m_Instantiate;
    //! Stage1_1
    GameObject OMaruo;
    GameObject OLope;
    GameObject OBackLane;
    GameObject BackLane01;

    private void Start()
    {
        OMaruo = GameObject.Find("Maruo");
        OLope = GameObject.Find("Lope");
        OBackLane = GameObject.Find("BackLane");
    }

    public void Stage1()
    {
        OBackLane.GetComponent<BackLane>().Spawn();

        BackLane01 = GameObject.Find("BackLane01");
        iTween.MoveBy(BackLane01, iTween.Hash("x", 25f, "time", 2f,"delay",2f));

        OMaruo.GetComponent<Maruo>().Spawn();
        OLope.GetComponent<Lope>().Spawn();
    }
}
