using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanban : MonoBehaviour
{
    public GameObject KANBAN;

    public void Move()
    {
        Debug.Log("よしき");

        //! animation
        iTween.MoveBy(KANBAN, iTween.Hash("y", 10, "time", 1f, "delay", 2f));
    }
}
