using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Player[] player = new Player[2];
    private int PlayerIndex;

    

    // Start is called before the first frame update
    void Start()
    {
        int i = PlayerIndex = 0;
        foreach(Transform trans in transform)
        {
            player[i] = trans.GetComponent<Player>();
            //Debug.Log(player[i].name);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {

        player[PlayerIndex].UpdateP();

        if (Input.GetButtonDown("GamePad1_LRTrigger"))
        {
            PlayerIndex = (PlayerIndex + 1) % 2;
        }

        if (Input.GetButtonDown("GamePad1_button_Start"))
        {

        }
    }

    private void FixedUpdate()
    {
        player[PlayerIndex].FixedUpdateP();
    }

}
