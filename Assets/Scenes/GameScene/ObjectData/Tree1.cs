using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree1 : MonoBehaviour
{
    public GameObject Tree1Prefab;

    public ObjectsData Tree1Data;

    public void Spawn()
    {
        Debug.Log("Tree1Init");

        Instantiate(Tree1Prefab, Tree1Data.spawnPoints[0],Tree1Data.q);
    }
}

