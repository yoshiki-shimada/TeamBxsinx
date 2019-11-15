using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    Renderer[] HPmaterials = new Renderer[3];  // HPライトのTextureの参照
    [SerializeField] Material Blackmaterial;

    Material[] copymat = new Material[3];
    //[SerializeField] Player player;

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach(Transform child in transform)
        {
            HPmaterials[i] = child.GetChild(0).GetComponent<Renderer>();
            HPmaterials[i].material.EnableKeyword("_EMISSION");
            Debug.Log(HPmaterials[i].name);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Off(int damage)
    {
        copymat[damage] = HPmaterials[damage].material;
        HPmaterials[damage].material = Blackmaterial;

        /*iTween.ValueTo(gameObject, iTween.Hash(
            "from", 2.2f,
            "to", -10f,
            "time", 2f,
            "onupdate", "SetIntensity",
            "onupdateparams",damage,
            "onupdatetarget", gameObject,
            "oncomplete", "SetBlackMaterial",
            "oncompleteparams",damage,
            "oncompletetraget", gameObject));*/
    }
   /* void SetIntensity(float vale,int damage)
    {

        HPmaterials[damage].SetColor("_EmissionColor",
            HPmaterials[damage].GetColor("_Emission") * vale);
    }
    void SetBlackMaterial(int damage)
    {
        copymat[damage] = HPmaterials[damage];
        HPmaterials[damage] = Blackmaterial;
        copymat[damage].SetColor("_EmissionColor",
            copymat[damage].GetColor("_Emission") * 2.2f);
    }*/
}
