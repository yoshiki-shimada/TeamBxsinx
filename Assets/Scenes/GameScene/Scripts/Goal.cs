using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //public GameObject SceneManager;
    GameObject SceneManager;

    private void Start()
    {
        SceneManager = GameObject.Find("SceneManager");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("おれさいきょう");
        SceneManager.GetComponent<GameSceneManager>().m_bStageFlag = true;
    }
}
