using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class WallAnim : MonoBehaviour
{
    private PlayableDirector playableDirector;

    public void Move()
    {
        playableDirector.Play();
    }
}
