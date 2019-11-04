using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Shadow : MonoBehaviour
{
    
    [SerializeField] private float ShadowZ;
    private float OppositeShadowZ;
    public float oppositeZ
    {
        set { OppositeShadowZ = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //影の生成
    public void CreateShadow(Transform[] CenterObjects,Rigidbody[] ShadowObjects)
    {
        int i = 0;
        foreach (Transform game in CenterObjects)
        {
            float x = game.transform.position.x * 2 - transform.position.x;
            float y = game.transform.position.y * 2 - transform.position.y;
            Vector3 pos = new Vector3(x, 
                (ShadowObjects[i].transform.position.y - y),
                ShadowZ);
                
            ShadowObjects[i].MovePosition(pos);
            i++;
        }
    }

    public void ChangeLight(bool IsLight,float distination
        ,GameObject game,Rigidbody[] Shadow)
    {
        iTween.MoveTo(gameObject, iTween.Hash(
            "y", distination,
            "time", 1.6f,
            "easeType", iTween.EaseType.easeInOutQuint,
            "isLocal", true,
            "oncomplete", "ChangeLight_End",
            "oncompletetarget", game
            ));

        if (IsLight)
            ChangeShadow(Shadow);
    }

    void ChangeShadow(Rigidbody[] Shadow)
    {
        for (int i = 0; i < Shadow.Length; i++)
        {
            iTween.ValueTo(Shadow[i].gameObject, iTween.Hash(
                "from", Shadow[i].transform.localPosition.y,
                "to", Shadow[i].transform.localPosition.y - 5f,
                "time", 0.8f,
                "easeType", iTween.EaseType.easeInOutQuint,
                "onupdatetarget", gameObject,
                "onupdate", "ChsngeShadowMove",
                "oncompletetarget", gameObject,
                "oncompleat", "ChangeShadowOpposite",
                "oncompleatparams", Shadow));

        }
    }
    void ChangeShadowOpposite(Rigidbody[] Shadow)
    {

    }
    void ChangeShadowMove(float y)
    {

    }

}
