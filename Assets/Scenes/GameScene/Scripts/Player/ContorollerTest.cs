using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContorollerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("GamePad1_buttonB"))
        {
            Debug.Log("buttonB");
        }
        if (Input.GetButtonDown("GamePad1_buttonX"))
        {
            Debug.Log("buttonX");
        }
        if (Input.GetButtonDown("GamePad1_button_Start"))
        {
            Debug.Log("button_Start");
        }
       /* float hori = Input.GetAxis("H");
       // float vert = Input.GetAxis("Vertical");
        if ( hori != 0 )
        {
            Debug.Log("stick:" + hori);
        }*/
      /*  if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("DKey_Down");
        }*/

        float lsh = Input.GetAxis("GamePad1_LeftStick_H");
        if (lsh != 0)
        {
            Debug.Log("Lstick:" + lsh);
        }

        float tri = Input.GetAxis("GamePad1_LRTrigger");
        if (tri > 0)
        {
            Debug.Log("R trigger:" + tri);
        }
        else if (tri < 0)
        {
            Debug.Log("L trigger:" + tri);
        }
        /*else if(tri==0)
        {
            Debug.Log("trigeer 0");
        }*/
    }
}
