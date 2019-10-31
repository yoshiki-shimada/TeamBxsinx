using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Shadow : MonoBehaviour
{
    private GameObject[] CenterObjects; //真ん中のオブジェクト
    private GameObject[] ShadowObjects; //影のオブジェクト

    [SerializeField] private float ShadowY, ShadowZ;
    // Start is called before the first frame update
    void Start()
    {
        GetCenterObj();
    }

    // Update is called once per frame
    void Update()
    {
        CreateShadow();
    }

    //真ん中のオブジェクトと影のオブジェクト取得
    void GetCenterObj()
    {
        CenterObjects = GameObject.FindGameObjectsWithTag("CenterObject");
        Debug.Log(CenterObjects[0].name);
        int i = 0;
        ShadowObjects = new GameObject[CenterObjects.Length];
        foreach (GameObject game in CenterObjects)
        {
            ShadowObjects[i] = game.transform.GetChild(0).gameObject;
            Debug.Log(ShadowObjects[i].name);
            i++;
        }

    }

    //影の生成
    void CreateShadow()
    {
        foreach (GameObject game in CenterObjects)
        {
            float x = game.transform.position.x * 2 - transform.position.x;
            float y = game.transform.position.y * 2 - transform.position.y;
            Vector3 pos = new Vector3(x, ShadowY, ShadowZ);
                
            ShadowObjects[0].transform.position = pos;
        }
    }

    /*void MoveShadow()
    {

    }*/
}
