using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
  private GameObject[] character;
    private bool[] m_benabled;
    // Start is called before the first frame update
    void Start()
    {
        character = new GameObject[transform.childCount];
        m_benabled = new bool[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            character[i] = transform.GetChild(i).gameObject;
            Debug.Log(character[i].name);
            m_benabled[i] = character[i].GetComponent<Player>().enabled;
           // Debug.Log(m_benabled[i]);
        }
        character[1].GetComponent<Player>().enabled = m_benabled[1] = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("GamePad1_LRTrigger"))
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                m_benabled[i] = !m_benabled[i];
                character[i].GetComponent<Player>().enabled = m_benabled[i];
            }
        }

        if (Input.GetButtonDown("GamePad1_button_Start"))
        {

        }
    }
}
