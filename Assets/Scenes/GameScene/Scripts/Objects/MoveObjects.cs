using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    //ObjectInstantiate m_Instantiate;
    public GameObject SceneManager;

    GameObject BG;
    GameObject Maruo;

    //! Stage1_1
    GameObject OLope;
    GameObject OBackLane;
    GameObject BackLane01;
    GameObject KANBAN;

    //! Stage2_2
    GameObject Button;
    GameObject OWall;
    GameObject MoveWall;

    private void Start()
    {
        SceneManager = GameObject.Find("SceneManager");
        BG = GameObject.Find("BG");
        Maruo = GameObject.Find("MaruoSin");
        BackLane01 = GameObject.Find("BackLane01");
        OLope = GameObject.Find("Lope");
        OBackLane = GameObject.Find("BackLane");
        KANBAN = GameObject.Find("KANBAN");
        Button = GameObject.Find("Switch");
        OWall = GameObject.Find("StoneWall");
        MoveWall = GameObject.Find("MoveWall");
    }

    public void Stage1()
    {
        if (SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag)
        {
            BG.GetComponent<BGAnimation>().ForestBG();
            KANBAN.GetComponent<Kanban>().Move();
            OBackLane.GetComponent<BackLane>().Spawn();
            iTween.MoveBy(BackLane01, iTween.Hash("x", 27f, "time", 2f, "delay", 2f));
            Maruo.GetComponent<Maruo>().InObj();
            OLope.GetComponent<Lope>().SpawnBack();
            SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag = false;
        }
        else {

            SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag = true;
            OBackLane.GetComponent<BackLane>().Move();
            iTween.MoveBy(BackLane01, iTween.Hash("x", -28f, "time", 1f));      //  delay
            OLope.GetComponent<Lope>().Delete();
            OBackLane.GetComponent<BackLane>().Delete();
        }
    }

    public void Stage2()
    {
        if (SceneManager.GetComponent<GameSceneManager>().m_bStageFlag)
        {
            Button.GetComponent<Switch>().Spawn();
            OWall.GetComponent<StoneWall>().SpawnBack();
            MoveWall.GetComponent<MoveWall>().SpawnFront();
            OLope.GetComponent<Lope>().SpawnFront();
            SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag = false;
        }
        else
        {

            SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag = true;
            OWall.GetComponent<StoneWall>().Delete();
            MoveWall.GetComponent<MoveWall>().Delete();
            OLope.GetComponent<Lope>().Delete();
            Button.GetComponent<Switch>().Delete();
        }
    }

    public void Stage3()
    {

    }
}