using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public ObjectsData EnemyData;

    private GameObject t;

    public void SpawnFront()
    {
        //! CloneInstance
        t = Instantiate(EnemyPrefab, EnemyData.spawnPoints[0], EnemyData.q2) as GameObject;
    }

    public void SpawnBack()
    {
        //! CloneInstance
        t = Instantiate(EnemyPrefab, EnemyData.spawnPoints[0], EnemyData.q2) as GameObject;
    }

    public void Delete()
    {
        Destroy(t);
    }
}
