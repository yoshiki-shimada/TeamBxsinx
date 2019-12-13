using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //soundmanager呼び込み-------------------------------------
    GameObject soundManager;

    [SerializeField]
    ScrollObject Tanaka;

    private Player[] player = new Player[2];
    private int PlayerIndex;

    [SerializeField]
    FadeManager fade;
    public FadeManager Fade
    {
        get { return fade; }
    }

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManager");

        int i = PlayerIndex = 0;
        foreach (Transform trans in transform)
        {
            player[i] = trans.GetComponent<Player>();
            //Debug.Log(player[i].name);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 2; i++)
            player[i].IsJump();

        player[PlayerIndex].UpdateP();

        if (Input.GetButtonDown("GamePad1_buttonY"))
        {
            PlayerIndex = (PlayerIndex + 1) % 2;
            soundManager.GetComponent<SoundManager>().changeplayerSE();

        }

        if (Input.GetButtonDown("GamePad1_button_Start"))
        {

        }
    }

    private void FixedUpdate()
    {
        player[PlayerIndex].FixedUpdateP();
    }

    public IEnumerator ResetPlayer()
    {
        //Debug.Log("IsReset");
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 2; i++)
        {
            player[i].ReSet();
        }
    }

}
