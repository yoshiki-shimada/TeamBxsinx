using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BackY    1.6
// FrontY   -0.4

public class Goal : MonoBehaviour
{
    //public GameObject SceneManager;
    GameObject SceneManager;

    [SerializeField] float[] Destination = new float[2];
    int DesIndex;
    public int Desindex
    {
        set { DesIndex = value; }
    }

    private void Start()
    {
        SceneManager = GameObject.Find("SceneManager");
        DesIndex = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("おれさいきょう");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player player = collision.transform.GetComponent<Player>();
            if ((PlayerState)player.PState == PlayerState.Jump)
            {
                player.Clear = true;
                DownLope(player.gameObject);
            }
        }
          //  SceneManager.GetComponent<GameSceneManager>().m_bStageFlag = true;
    }

    void DownLope(GameObject player)
    {
        iTween.MoveTo(this.gameObject,
            iTween.Hash(
                "y", Destination[DesIndex],
                "time", 0.6f,
                "delay",0.1f,
                "easeType", iTween.EaseType.spring));
        iTween.MoveTo(player,
            iTween.Hash(
                "y", Destination[DesIndex],
                "time", 0.6f,
                "delay", 0.1f,
                "easeType", iTween.EaseType.spring));
    }
}
