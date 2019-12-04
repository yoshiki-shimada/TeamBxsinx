using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] CatInPrefab;

    [SerializeField]
    GameObject canvas;

    private GameObject CreentCatIn;

    int i;
    bool InFlag;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        InFlag = true;
        CreentCatIn = (GameObject)Instantiate(CatInPrefab[i]);
    }

    // Update is called once per frame
    public bool isCatIn()
    {
        if (InFlag)
        {
            CreentCatIn.transform.SetParent(canvas.transform, false);
            iTween.MoveAdd(CreentCatIn, iTween.Hash("y", -21, "time", 3.0f));
            InFlag = false;
        }

        if (Input.GetButtonDown("GamePad1_buttonB"))
        {
            iTween.MoveBy(CreentCatIn, iTween.Hash("x", -100f, "time", 10.0f));
            i++;
            CreentCatIn = (GameObject)Instantiate(CatInPrefab[i]);
            return true;
        }
        return false;
    }
}
