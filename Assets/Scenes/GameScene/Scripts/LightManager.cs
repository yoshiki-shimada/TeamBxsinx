using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] private Light_Shadow[] light_s;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < light_s.Length; i++)
        {
            light_s[i].enabled = false;
        }
        light_s[0].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ChageLight()
    {
        for(int i = 0; i < light_s.Length; i++)
        {
            bool change = light_s[i].enabled;
            light_s[i].enabled = !change;
        }
    }
}
