using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    private GameObject[] CenterObjects;
    private GameObject[] ShadowObjects;

    // Start is called before the first frame update
    void Start()
    {
        GetCenterObj();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetCenterObj()
    {
        CenterObjects = GameObject.FindGameObjectsWithTag("CenterObject");

        ShadowObjects = GameObject.FindGameObjectsWithTag("ShadowObject");
        foreach(GameObject game in ShadowObjects)
        {
            game.SetActive(false);
        }
    }

    void CreateShadow()
    {

    }

    void MoveShadow()
    {

    }
}
