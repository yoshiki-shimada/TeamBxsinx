using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree1 : MonoBehaviour
{
    [SerializeField]
    ObjectsData Tree1Data;

    private void Update()
    {
        Debug.Log(Tree1Data.prefabName);
    }
}

