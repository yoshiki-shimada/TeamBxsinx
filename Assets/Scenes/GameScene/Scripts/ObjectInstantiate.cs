using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantiate : MonoBehaviour
{
    public GameObject Tree1;


    // Start is called before the first frame update
    void Start()
    {
        //nPageCounter = 0;
    }

    public void NextPage(int nPage)
    {
        if(nPage == 1)
        {
            Debug.Log("gsa");
            Instantiate(Tree1, new Vector3(0.0f, 2.0f, 3.0f), Quaternion.identity);
        }

        return;
    }
}
