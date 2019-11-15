using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    private Transform[] CenterObjects; //真ん中のオブジェクト
    private Rigidbody[] ShadowObjects; //影のオブジェクト

    [SerializeField] private Light_Shadow[] light_s;
    private int lightIndex;
    //[SerializeField]
    private float[] LocalPosY= new float[2];
    private bool changeLight;
    public bool changelight
    {
        get { return changeLight; }
    }
    // Start is called before the first frame update
    void Start()
    {
        GetCenterObj();
        lightIndex = 0;
        changeLight = false;
        LocalPosY[0] = light_s[0].transform.localPosition.y;
        LocalPosY[1] = light_s[1].transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
       // if (!changeLight)
        {
                light_s[lightIndex].CreateShadow(CenterObjects, ShadowObjects);
            
        }
    }

    //真ん中のオブジェクトと影のオブジェクト取得
    public void GetCenterObj()
    {
        GameObject[] Objects = GameObject.FindGameObjectsWithTag("CenterObject");

        //  Debug.Log(CenterObjects[0].name);
        CenterObjects = new Transform[Objects.Length];
        ShadowObjects = new Rigidbody[Objects.Length];
        int i = 0;
        foreach (GameObject game in Objects)
        {
            CenterObjects[i] = game.transform;
            ShadowObjects[i] = CenterObjects[i].GetComponentInChildren<Rigidbody>();
            Debug.Log(ShadowObjects[i].name);
            i++;
        }
        i = 0;
    }
    
    public void ChageLight()
    {
        if (changeLight)
            return;
        changeLight = true;
        
        for(int i = 0; i < light_s.Length; i++)
        {
            if (i == lightIndex)
            {
                light_s[i].ChangeLight(LocalPosY[1],gameObject);
                Invoke("ChangeLight_End", 0.9f);
            }
            else
            {
                light_s[i].ChangeLight(LocalPosY[0],gameObject);
            }
        }
    }
    void ChangeLight_End()
    {
        lightIndex =(1 + lightIndex) % 2;
    }
    void ChangeLight_flag()
    {
        changeLight = false;
    }

}
