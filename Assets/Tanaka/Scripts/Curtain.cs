using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtain : MonoBehaviour
{
    public GameObject[] curtain;

    // Start is called before the first frame update
    void Awake()//Start()
    {
        curtain[0].transform.localScale = new Vector3(7.5f, 1, 1);
        curtain[1].transform.localScale = new Vector3(7.5f, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        float localscaleL = curtain[0].transform.localScale.x;
        float localscaleR = curtain[0].transform.localScale.x;
        if (localscaleL <= 7.5 && localscaleL > 1)
        {
             curtain[0].transform.localScale = new Vector3(localscaleL, 0, 0);
             curtain[1].transform.localScale = new Vector3(localscaleR, 0, 0);
        }
    }
}
