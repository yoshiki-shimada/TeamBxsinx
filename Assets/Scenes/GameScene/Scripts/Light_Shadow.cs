using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Shadow : MonoBehaviour
{
    private GameObject[] CenterObjects; //真ん中のオブジェクト
    private GameObject[] ShadowObjects; //影のオブジェクト

    private float ShadowY, ShadowZ; //影のY、Z座標
    private bool LightPosFlag = true;//
    private bool Lightflag = true;  //光源のレーン移動関連です
    public bool  LightFlag{         //消してもいいです
        set { Lightflag = value; }
        get { return Lightflag; }
    }
    // Start is called before the first frame update
    void Start()
    {
        GetCenterObj();
    }

    // Update is called once per frame
    void Update()
    {
        if (LightPosFlag != LightFlag)
        {

        }
        CreateShadow();
    }

    //真ん中のオブジェクトと影のオブジェクト取得
    void GetCenterObj()
    {
        CenterObjects = GameObject.FindGameObjectsWithTag("CenterObject");
            Debug.Log(CenterObjects[0].name);
        int i = 0;
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
            Vector3 pos = new Vector3(x, 2.64f, 6);
            ShadowObjects[0].transform.position = pos;
        }
    }

    /*void MoveShadow()
    {

    }*/
}
