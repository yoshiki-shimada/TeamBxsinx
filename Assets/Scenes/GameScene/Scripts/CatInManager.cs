using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            iTween.MoveAdd(CreentCatIn, iTween.Hash("y", -21, "time", 2.0f));
            InFlag = false;

        }

        if (Input.GetButtonDown("GamePad1_buttonA"))
        {
            iTween.MoveAdd(CreentCatIn, iTween.Hash("y", -80f, "time", 10.0f,"oncomplete","NextCat","oncompletetarget",CreentCatIn));
            i++;
            InFlag = true;
            CreentCatIn = (GameObject)Instantiate(CatInPrefab[i]);
            for (int timeCount = 100; timeCount >= 0; timeCount--)
            {
                if (timeCount <= 0)
                {
                    foreach (Transform child in canvas.transform)
                        Destroy(child.gameObject);
                }
            }
            return true;
        }
        return false;
    }
}