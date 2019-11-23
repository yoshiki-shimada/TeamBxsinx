using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    bool Flag;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Flag = true;
    }

    void OnTriggerEnter(Collider pther)
    {
        if (Flag)
        {
            Debug.Log("SwicthON");
            anim.enabled = true;
            anim.Play("botann");
            Flag = false;
        }
    }
}
