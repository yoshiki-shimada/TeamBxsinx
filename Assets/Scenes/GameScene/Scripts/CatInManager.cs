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

    [SerializeField]
    PlayerHP FHP;
    [SerializeField]
    PlayerHP BHP;   

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
            FHP.MoveHPLight(-2f);
            BHP.MoveHPLight(-2f);
            CreentCatIn.transform.SetParent(canvas.transform, false);
            iTween.MoveAdd(CreentCatIn, iTween.Hash("y", -21, "time", 2.0f));
            InFlag = false;
        }

        if (Input.GetButtonDown("GamePad1_buttonA"))
        {
            FHP.MoveHPLight(0f);
            BHP.MoveHPLight(0f);
            iTween.MoveAdd(CreentCatIn, iTween.Hash("y", -80f, "time", 10.0f, "oncomplete", "NextCat", "oncompletetarget", CreentCatIn));
            i++;
            InFlag = true;
            CreentCatIn = (GameObject)Instantiate(CatInPrefab[i]);

            foreach (Transform child in canvas.transform)
                Destroy(child.gameObject);

            return true;
        }
        return false;
    }
}