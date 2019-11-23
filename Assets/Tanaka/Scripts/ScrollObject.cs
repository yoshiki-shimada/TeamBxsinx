using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public float speedX;
    public float startPosition;
    public float endPosition;

    private bool pushYFlag;
    private float hori;
    // Start is called before the first frame update
    void Start()
    {
        pushYFlag = false;

    }
    

    // Update is called once per frame
    void Update()
    {
        buttonflag();
        Move();
    }

    void buttonflag()
    {
        if (Input.GetButtonDown("GamePad1_buttonY") && !pushYFlag) { pushYFlag = true; }
        else if (Input.GetButtonDown("GamePad1_buttonY") && pushYFlag) { pushYFlag = false; }
    }

    void Move()
    {
        hori = Input.GetAxisRaw("GamePad1_LeftStick_H");

        if (pushYFlag)
        {
            if (hori < 0)
            {
                if (transform.position.x >= endPosition)
                    transform.position -= new Vector3(speedX * Time.deltaTime, 0, 0);
            }else if (hori > 0)
            {
                if (transform.position.x >= endPosition)
                    transform.position += new Vector3(speedX * Time.deltaTime, 0, 0);
            }
            ScrollEnd();
        }
    }

    void ScrollEnd()
    {
        if (transform.position.x <= endPosition)
        {
            //Destroy(this.gameObject);
            transform.position = new Vector3(startPosition, 0, 0);
        }
        else if (transform.position.x >= startPosition)
        {
            //Destroy(this.gameObject);
            transform.position = new Vector3(endPosition, 0, 0);
        }

    }
}
