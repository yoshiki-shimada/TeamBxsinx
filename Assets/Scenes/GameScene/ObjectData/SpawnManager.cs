using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // !    オブジェクトのインスタンス化
    public GameObject entityToSpawn;

    //! 上のゲームScriptableObjectのインスタンス
    public ObjectsData spawnManaferValues;

    //! インスタンスナンバー
    int instanceNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEntities();
    }

    void SpawnEntities()
    {
        int currentSpawnPointIndex = 0;


    }
}
