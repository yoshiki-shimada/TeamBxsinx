using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActiveLight : byte
{
    Front,
    Back,
    None,
};

public class LightManager : MonoBehaviour
{
    private Transform[] CenterObjects; //真ん中のオブジェクト
    private Rigidbody[] ShadowObjects; //影のオブジェクト

    [SerializeField] private GameObject FLight;
    [SerializeField] private GameObject BLight; 
    [SerializeField] private GameObject[] pointLights;    //spotLigth
    [SerializeField] private Light_Shadow[] light_s;
    ActiveLight light_on;
    private bool[] lightFlag = new bool[2];
    //[SerializeField]
    private float[] LocalPosY = new float[2];
    private bool changeLight;
    //-------------------------------------------
    public bool pointlightOn;
    //-------------------------------------------
    public bool changelight
    {
        get { return changeLight; }
    }
    // Start is called before the first frame update
    void Start()
    {

        GetCenterObj();
        light_on = ActiveLight.Front;
        lightFlag[0] = true;
        lightFlag[1] = false;

        changeLight = false;
        LocalPosY[0] = light_s[0].transform.localPosition.y;
        LocalPosY[1] = light_s[1].transform.localPosition.y;

        //---------------------------------------
        pointlightOn = false;
        //---------------------------------------

    }


    private void FixedUpdate()
    {
        if (light_on != ActiveLight.None)
            light_s[(int)light_on].CreateShadow(CenterObjects, ShadowObjects);
        //else
        putOnPointlight();
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

    }

    public void ChageLight(ActiveLight playernum)
    {
        if (changeLight)
            return;
        changeLight = true;

        if (light_on == playernum)
        {
            light_s[(int)playernum].ChangeLight(LocalPosY[1], gameObject);
            StartCoroutine(ChangeLight_End(ActiveLight.None, 1.2f));
        }
        else if (light_on == ActiveLight.None)
        {
            light_s[(int)playernum].ChangeLight(LocalPosY[0], gameObject);
            StartCoroutine(ChangeLight_End(playernum, 0.2f));
        }
        else
        {
            for (int i = 0; i < light_s.Length; i++)
            {
                if (i == (int)light_on)
                {
                    light_s[i].ChangeLight(LocalPosY[1], gameObject);

                    StartCoroutine(ChangeLight_End((ActiveLight)((int)(light_on + 1) % 2),
                        0.9f));
                }
                else
                    light_s[i].ChangeLight(LocalPosY[0], gameObject);
            }

        }
    }
    IEnumerator ChangeLight_End(ActiveLight nextLight, float time)
    {
        yield return new WaitForSeconds(time);
        light_on = nextLight;

        if (light_on == ActiveLight.None)
        {
            NoneShadow();
        }
        /*               Yui[0].SetActive(false);
                       Yui[1].SetActive(false);
                   if (light_on == ActiveLight.Front)
                   {
                       Yui[0].SetActive(true);
                       Yui[1].SetActive(false);
                   }
                   else if (light_on == ActiveLight.Back)
                   {
                       Yui[0].SetActive(false);
                       Yui[1].SetActive(true);
                   }
        */
    }

    void NoneShadow()
    {
        foreach (Rigidbody shadow in ShadowObjects)
        {
            shadow.transform.localPosition = new Vector3(0, -2, 0);
        }
    }

    void ChangeLight_flag()
    {
        changeLight = false;
    }

    void putOnPointlight()
    {
        //flag
        if (light_s[0].transform.localPosition.y < LocalPosY[1]
            || light_s[1].transform.localPosition.y < LocalPosY[1])
        {
            pointlightOn = false;
        }
        else { pointlightOn = true; }
       
        //Front
        if (light_s[0].transform.localPosition.y > LocalPosY[0]) { FLight.SetActive(false); }
        else if (light_s[0].transform.localPosition.y <= LocalPosY[0]) { FLight.SetActive(true); }
        //Back
        if (light_s[1].transform.localPosition.y > LocalPosY[0]) { BLight.SetActive(false); }
        else if (light_s[1].transform.localPosition.y <= LocalPosY[0]) { BLight.SetActive(true); }

        //処理
        if (pointlightOn)
        {
            for (int i = 0; i < pointLights.Length; i++) { pointLights[i].SetActive(true); }
        }
        else
        {
            for (int i = 0; i < pointLights.Length; i++) { pointLights[i].SetActive(false); }
        }
    }
}
