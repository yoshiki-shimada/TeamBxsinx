using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanban : MonoBehaviour
{
    public GameObject KANBAN;

    public ObjectsData KanbanData;

    public void Move()
    {
        Debug.Log("よしき");
       
        //! animation
        iTween.MoveBy(KANBAN, iTween.Hash("y", KanbanData.OInitAnim[0].y, "time", 1f, "delay", 2f));
    }
}
