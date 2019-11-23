using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterLaneController : MonoBehaviour
{
    const float CenterLaneSize = 52.5f;

    int currentLaneIndex;

    public GameObject[] CenterLaneTips;
    public Transform centerLane;
    public int startLane;
    public int endLane;
    public int preInstantiate;
    public List<GameObject> generatedCenterLaneList = new List<GameObject>();
    public float speedX;
    public bool changeFlag=false;

    // Start is called before the first frame update
    void Start()
    {
        currentLaneIndex = startLane - 1;
        UpdatecenterLane(preInstantiate);
    }

    // Update is called once per frame
    void Update()
    {

        //センターラインのポジションを取得
        int centerLanePositionIndex = (int)centerLane.position.x;

        //'Y'を押したときの処理
        if (Input.GetButtonDown("GamePad1_buttonY"))
        {
            //changeFlag = true;
            if (centerLanePositionIndex + preInstantiate > currentLaneIndex)
            {
                UpdatecenterLane(currentLaneIndex+centerLanePositionIndex);
            }
        }
    }

    void UpdatecenterLane(int toLaneIndex)
    {
        if (toLaneIndex <= currentLaneIndex) return;

        //生成したラインチップを作成
        for(int i = currentLaneIndex + 1; i <= toLaneIndex; i++)
        {
            GameObject LaneObject = GenerateLane(i);

            //生成したラインチップを管理リストに追加
            generatedCenterLaneList.Add(LaneObject);
        }

        //ライン保持上限内までになるまで古いラインを削除
        while (generatedCenterLaneList.Count > preInstantiate + 2) DestroyOldestLane();

        currentLaneIndex = toLaneIndex;
    }

    //指定のインデックス位置にラインオブジェクトを生成
    GameObject GenerateLane(int laneIndex)
    {
        int nextLane = CenterLaneTips.Length;

        GameObject laneObject = (GameObject)Instantiate(
            CenterLaneTips[nextLane],
            new Vector3(laneIndex * CenterLaneSize, 0, 0),
            Quaternion.identity
            );

        return laneObject;
    }

    //一番古いラインを削除
    void DestroyOldestLane()
    {
        GameObject oldLane = generatedCenterLaneList[0];
        generatedCenterLaneList.RemoveAt(0);
        Destroy(oldLane);
    }
}
