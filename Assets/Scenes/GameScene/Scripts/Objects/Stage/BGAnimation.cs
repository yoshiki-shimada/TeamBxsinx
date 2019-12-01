using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAnimation : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ForestBG()
    {
        anim.SetBool("animFlag", false);
    }
}
