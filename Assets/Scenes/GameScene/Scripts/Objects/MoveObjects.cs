using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    //ObjectInstantiate m_Instantiate;
    public GameObject SceneManager;

    GameObject BG;

    //! Stage1_1
    GameObject OMaruo;
    GameObject OLope;
    GameObject OBackLane;
    GameObject BackLane01;
    GameObject KANBAN;

    private void Start()
    {
        SceneManager = GameObject.Find("SceneManager");
        BG = GameObject.Find("BG");
        BackLane01 = GameObject.Find("BackLane01");
        OMaruo = GameObject.Find("Maruo");
        OLope = GameObject.Find("Lope");
        OBackLane = GameObject.Find("BackLane");
        KANBAN = GameObject.Find("KANBAN");
    }

    public void Stage1()
    {
        if (SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag)
        {
            BG.GetComponent<BGAnimation>().ForestBG();

            KANBAN.GetComponent<Kanban>().Move();

            OBackLane.GetComponent<BackLane>().Spawn();
            iTween.MoveBy(BackLane01, iTween.Hash("x", 25f, "time", 2f, "delay", 2f));

            OMaruo.GetComponent<Maruo>().Spawn();
            OLope.GetComponent<Lope>().SpawnFront();
            SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag = false;
        }
        else {

            SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag = true;
            OBackLane.GetComponent<BackLane>().Move();
            iTween.MoveBy(BackLane01, iTween.Hash("x", -25f, "time", 1f));      //  delay
            OLope.GetComponent<Lope>().Delete();
            OBackLane.GetComponent<BackLane>().Delete();
        }
    }

    public void Stage2()
    {
        if (SceneManager.GetComponent<GameSceneManager>().m_bStageFlag)
        {

            OLope.GetComponent<Lope>().SpawnFront();
            SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag = false;
        }
    }
}