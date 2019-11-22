using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    Renderer[] HPmaterials = new Renderer[3];  // HPライトのTextureの参照
    [SerializeField] Material Blackmaterial;

    Material[] copymat = new Material[3];
    int damag;
    //[SerializeField] Player player;

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach(Transform child in transform)
        {
            HPmaterials[i] = child.GetChild(0).GetComponent<Renderer>();
            HPmaterials[i].material.EnableKeyword("_EMISSION");
            //Debug.Log(HPmaterials[i].name);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Off(int damage)
    {
        damag = damage;
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", 1.8f,
            "to", -1f,
            "time", 1f,
            "onupdate", "SetIntensity",
            //"onupdateparams",damage,
            "onupdatetarget", gameObject,
            "oncomplete", "SetBlackMaterial",
            "oncompleteparams",damage,
            "oncompletetraget", gameObject));
    }
    void SetIntensity(float vale)
    {

        HPmaterials[damag].material.SetColor("_EmissionColor",
            HPmaterials[damag].material.GetColor("_EmissionColor") * vale);
    }
    void SetBlackMaterial(int damage)
    {
        copymat[damage] = HPmaterials[damage].material;
        HPmaterials[damage].material = Blackmaterial;
        copymat[damage].SetColor("_EmissionColor",
            copymat[damage].GetColor("_EmissionColor") * 1f);
    }
}
