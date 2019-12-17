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
        iTween.MoveBy(CreentCatIn, iTween.Hash("y", -500, "time", 6.0f));
        iTween.MoveAdd(CreentCatIn, iTween.Hash("y", 40, "time", 1.0f, "delay", 1.5f));
    }
}
