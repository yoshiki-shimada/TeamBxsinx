using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject FirstSelect;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(FirstSelect);
    }
}
