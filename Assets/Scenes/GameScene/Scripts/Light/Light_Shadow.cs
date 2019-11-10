using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Shadow : MonoBehaviour
{
    
    [SerializeField] private float ShadowY,ShadowZ;

    private Vector3 rot;
    // Start is called before the first frame update
    void Awake()
    {
        rot = transform.rotation.eulerAngles;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(rot);
    }

    //影の生成
    public void CreateShadow(Transform[] CenterObjects,Rigidbody[] ShadowObjects)
    {
        int i = 0;
        foreach (Transform game in CenterObjects)
        {
            float x = game.transform.position.x * 2 - transform.position.x;
            //Vector3 Lx = game.transform.InverseTransformPoint(transform.position);
            float y = game.transform.position.y * 2 - transform.position.y;
            Vector3 pos = new Vector3(x, //-Lx.x + game.position.x,// 
                game.position.y+(ShadowY-game.position.y)+y*0.2f,//ShadowY + (0.2f * y), //
                ShadowZ);
            //Debug.Log(ShadowObjects[i].position);

           /* Debug.Log(Lx);
            Debug.Log(-Lx.x + game.position.x);

            Debug.Log(game.position.y + (ShadowY - game.position.y) + y * 0.1f);
            Debug.Log(ShadowY + (0.05f * y) + 0.6f);*/
            ShadowObjects[i].MovePosition(pos);
            i++;
        }
    }

    public void ChangeLight(float distination,GameObject game)
    {
        iTween.MoveTo(gameObject, iTween.Hash(
            "y", distination,
            "time", 1.6f,
            "easeType", iTween.EaseType.easeInOutQuint,
            "isLocal", true,
            "oncomplete", "ChangeLight_flag",
            "oncompletetarget", game
            ));

    }


}
