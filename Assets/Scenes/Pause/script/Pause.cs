using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
//<<<<<<< HEAD
    void Start()
    {
        
    }
//=======
    //void Start()
    //{
    //    Input.GetButtonDown("GamePad1_Buttonab"){
    //        if ()
    //    }
    //}
//>>>>>>> a6ef6113c9c1bf3b58d3f190229b1136ad0f4d44

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("GamePad1_ButtonB")){
            Canvas canvas = GameObject.Find("Canvasitem").GetComponent<Canvas>();
            canvas.enabled = !canvas.enabled;
        }
    }

}
