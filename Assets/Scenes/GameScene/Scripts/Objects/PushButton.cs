using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    public Animator anim;

    [SerializeField]
    MoveWall m_fMWall;

    void OnTriggerEnter(Collider pther)
    {
            Debug.Log("SwicthON");
            anim.enabled = true;
            anim.Play("botann");
            m_fMWall.GetComponent<MoveWall>().Move();
    }
}
