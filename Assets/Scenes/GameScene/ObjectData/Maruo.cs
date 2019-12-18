using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maruo : MonoBehaviour
{
    public ObjectsData ShadowObjectData;

     public void InObj()
    {
        //! animation
        Debug.Log("せんたーれーｍｎ");
        iTween.MoveTo(this.gameObject, iTween.Hash("x", ShadowObjectData.OInitAnim[0].x, "time", 1f, "delay", 3f));
    }
}
