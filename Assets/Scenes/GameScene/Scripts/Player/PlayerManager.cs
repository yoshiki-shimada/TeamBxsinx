using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Player[] player = new Player[2];
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach(Transform trans in transform)
        {
            player[i] = trans.GetComponent<Player>();
            player[i].enabled = false;
            i++;
        }
        player[0].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("GamePad1_LRTrigger"))
        {
            for (int i = 0; i < player.Length; i++)
            {
                bool playflag = player[i].enabled;
                player[i].enabled = !playflag;
            }
        }

        if (Input.GetButtonDown("GamePad1_button_Start"))
        {

        }
    }
}
