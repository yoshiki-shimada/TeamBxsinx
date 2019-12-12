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
    int DesIndex;           //! 0が手前、1が奥
    public int Desindex
    {
        set { DesIndex = value; }
    }
    Player player = null;

    private void Start()
    {
        SceneManager = GameObject.Find("SceneManager");
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("おれさいきょう");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player = collision.transform.GetComponent<Player>();
            if ((PlayerState)player.PState == PlayerState.Jump)
            {
                //Debug.Log(transform.position.x - player.transform.position.x);
                float dis = transform.position.x - player.transform.position.x;
                if ( dis < 0.7f && dis >= 0)
                {
                    player.transform.position =
                         new Vector3(transform.position.x - 0.9f,
                         transform.position.y, player.transform.position.z);
                    player.transform.localRotation = Quaternion.Euler(0,0,0);
                }
                else if(dis > -0.7f && dis < 0)
                {
                    player.transform.position =
                        new Vector3(transform.position.x + 0.9f,
                        transform.position.y, player.transform.position.z);
                    player.transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                player.Clear = true;
                DownLope(player.gameObject);
                StartCoroutine(ChangeScene());
            }
        }
    }

    void DownLope(GameObject player)
    {
        iTween.MoveTo(player,
    iTween.Hash(
        "y", Destination[DesIndex] + 0.3f,
        "time", 0.6f,
        "delay", 0.1f,
        "easeType", iTween.EaseType.spring,
        "oncomplete","ResetPlayer",
        "oncompletetarget",player.transform.parent.gameObject));

        iTween.MoveTo(this.gameObject,
            iTween.Hash(
                "y", Destination[DesIndex],
                "time", 0.6f,
                "delay",0.1f,
                "easeType", iTween.EaseType.spring));
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.GetComponent<GameSceneManager>().m_bStageFlag = true;
    }
}
