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
}
