using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    public Animator anim;

    [SerializeField]
    GameObject MObj;

    void OnTriggerEnter(Collider pther)
    {
        Debug.Log("SwicthON");
        anim.enabled = true;
        anim.Play("Down");
        MObj.GetComponent<WallAnim>().Move();
    }
}
