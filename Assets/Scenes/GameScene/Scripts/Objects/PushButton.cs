using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    public Animator anim;

    void OnTriggerEnter(Collider pther)
    {
            Debug.Log("SwicthON");
            anim.enabled = true;
            anim.Play("botann");
            gameObject.GetComponent<MoveWall>().Move();
    }
}
