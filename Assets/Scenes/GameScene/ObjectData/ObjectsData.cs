using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! ScriptableObjectアセット生成
[CreateAssetMenu(fileName = "Data",menuName = "ScriptableObjects/ObjectsData",order = 1)]
public class ObjectsData : ScriptableObject
{ 
    public string prefabName;

    public int numberOfPrefabsToCreate;

    public Vector3[] spawnPoints;

    public Vector3[] OInitAnim;

    public Vector3[] ODereteAnim;

    public Vector3[] OMoveAnim;

    public Quaternion q = new Quaternion();

    void Start()
    {
        q = Quaternion.identity;
    }
}
