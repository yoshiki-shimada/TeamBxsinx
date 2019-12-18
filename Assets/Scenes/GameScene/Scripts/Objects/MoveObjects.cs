using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    //ObjectInstantiate m_Instantiate;
    public GameObject SceneManager;

    GameObject BG;
    GameObject Maruo;

    [SerializeField] CenterObjManager center;
    GameObject[] Range3D=new GameObject[2];

    //! Tyuto1
    GameObject Maruta;

    //! Tyuto3

    //! Stage1_1
    GameObject OLope;
    GameObject OBackLane;
    GameObject BackLane01;
    GameObject KANBAN;

    //! Stage2_2
    GameObject Button;
    GameObject OWall;
    GameObject MoveWall;

    //! Stage2_3
    GameObject TuruYuka;
    GameObject Enemydes;

    private void Start()
    {
        SceneManager = GameObject.Find("SceneManager");
        BG = GameObject.Find("BG");
        Maruta = GameObject.Find("Maruta");
        Maruo = GameObject.Find("MaruoSin");
        BackLane01 = GameObject.Find("BackLane01");
        OLope = GameObject.Find("Lope");
        OBackLane = GameObject.Find("BackLane");
        KANBAN = GameObject.Find("KANBAN");
        Button = GameObject.Find("botann");
        OWall = GameObject.Find("StoneWall");
        MoveWall = GameObject.Find("MoveWall");
        TuruYuka = GameObject.Find("TuruYuka");
        Enemydes = GameObject.Find("Enemy1");
    }

    public void One()
    {
        if (SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag)
        {
            BG.GetComponent<BGAnimation>().ForestBG();
            KANBAN.GetComponent<Kanban>().Move();
            OLope.GetComponent<Lope>().SpawnFront();
            Maruta.GetComponent<PublicObj>().SpawnFront();
            SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag = false;
        }
        else
        {
            SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag = true;
            OLope.GetComponent<Lope>().Delete();
            Maruta.GetComponent<PublicObj>().Delete();
        }
    }

    public void two()
    {
        if (SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag)
        {
            OLope.GetComponent<Lope>().SpawnBack();
            Maruo.GetComponent<Maruo>().InObj();
            // 生成：[0]
            GameObject range = (GameObject)Resources.Load("Prefabs/3DRange");
            Range3D[0] = Instantiate(range, new Vector3(5.4f, 1.8f, 6.1f), Quaternion.identity);
            Range3D[0].GetComponent<SolidRange>().SetRange(5, 1);
            center.UpdateAllRange();
            SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag = false;
        }
        else
        {
            SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag = true;
            OLope.GetComponent<Lope>().Delete();
        }
    }

    public void three()
    {
        if (SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag)
        {
            OLope.GetComponent<Lope>().SpawnFront();
            Range3D[0].transform.position = new Vector3(6, 0.5f, 0.3f);
            Range3D[0].GetComponent<SolidRange>().SetRange(3, 1);
            SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag = false;
        }
        else
        {
            SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag = true;
            OLope.GetComponent<Lope>().Delete();
        }
    }

public void Stage1()
    {
        if (SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag)
        {
            OBackLane.GetComponent<BackLane>().Spawn();
            iTween.MoveBy(BackLane01, iTween.Hash("x", 27f, "time", 2f, "delay", 2f));
            OLope.GetComponent<Lope>().SpawnBack();
            Range3D[0].transform.position = new Vector3(4.65f, 1.8f, 6.1f);
            Range3D[0].GetComponent<SolidRange>().SetRange(5.35f, 1);
            SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag = false;
        }
        else
        {

            SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag = true;
            OBackLane.GetComponent<BackLane>().Move();
            iTween.MoveBy(BackLane01, iTween.Hash("x", -27f, "time", 1f));      //  delay
            OLope.GetComponent<Lope>().Delete();
            OBackLane.GetComponent<BackLane>().Delete();
        }
    }

    public void Stage2()
    {
        if (SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag)
        {
            Button.GetComponent<Switch>().Init();
            OWall.GetComponent<StoneWall>().SpawnBack();
            MoveWall.GetComponent<MoveWall>().SpawnFront();
            OLope.GetComponent<Lope>().SpawnFront();
            Range3D[0].transform.position = new Vector3(-0.4f, 1.8f, 6.1f);
            Range3D[0].GetComponent<SolidRange>().SetRange(4, 1);
            // 生成：「1」
            GameObject range = (GameObject)Resources.Load("Prefabs/3DRange");
            Range3D[1] = Instantiate(range, new Vector3(7.7f, 0.5f, 0.3f), Quaternion.identity);
            Range3D[1].GetComponent<SolidRange>().SetRange(3, 1);
            center.UpdateAllRange();
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
        if (SceneManager.GetComponent<GameSceneManager>().m_bMoveFlag)
        {
            OBackLane.GetComponent<BackLane>().Spawn();
            iTween.MoveBy(BackLane01, iTween.Hash("x", 20f, "time", 2f, "delay", 2f));
            TuruYuka.GetComponent<TuruYuka>().SpawnBack();
            OLope.GetComponent<Lope>().SpawnFront();
            Enemydes.GetComponent<Enemy>().SpawnBack();
        }
        else
        {
            OBackLane.GetComponent<BackLane>().Delete();
            iTween.MoveBy(BackLane01, iTween.Hash("x", -20f, "time", 1f));      //  delay
            TuruYuka.GetComponent<TuruYuka>().Delete();
            OLope.GetComponent<Lope>().Delete();
            Enemydes.GetComponent<Enemy>().Delete();
        }
    }

}