using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void hiretu() {
        for (int i = 0; i <= obj.Length; i++)
        {
            obj[i].transform=new Vector3(Left)
        }
    }
}
