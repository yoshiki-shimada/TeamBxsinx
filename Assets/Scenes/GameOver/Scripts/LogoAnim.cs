using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoAnim : MonoBehaviour
{
    [SerializeField]
    GameObject CatInPrefab;

    [SerializeField]
    GameObject canvas;

    private GameObject CreentCatIn;

    // Start is called before the first frame update
    void Start()
    {
        CreentCatIn = (GameObject)Instantiate(CatInPrefab);

        CreentCatIn.transform.SetParent(canvas.transform, false);
        iTween.MoveBy(CreentCatIn, iTween.Hash("y", -130, "time", 2.0f));
        iTween.MoveAdd(CreentCatIn, iTween.Hash("y", 20, "time", 0.5f, "delay", 1.0f));
    }
}
