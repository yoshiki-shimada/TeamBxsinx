using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// どの方向に進んでいるか
enum SpiderState
{
    SIDE,
    UP,
    DOWN,
    ROTATE,
}

public class Enemy_Spider : MonoBehaviour
{
    SphereCollider col;
    Rigidbody rb;
    int Direction = 1;
    SpiderState EState = SpiderState.SIDE;
    SpiderState NextState;
    Quaternion quat;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            RaycastHit hit2;
            if (Physics.Raycast(transform.position+transform.up*0.1f,
                -transform.up,//(transform.right * Direction) + (-transform.up),
                out hit2, 1.5f))
            {

                Debug.Log(hit2.distance);
            }

        }

        if (EState != SpiderState.ROTATE)
        {

            RaycastHit hit;
            if (EState <= SpiderState.SIDE)
            {
                if (Physics.Raycast(transform.position,
                    (transform.right) + (-transform.up),
                    out hit, 2f))
                {
                    Debug.Log(hit.distance);
                    if (hit.distance >= 0.01)
                        transform.position = hit.point;

                    Vector3 normal = hit.normal;
                    Quaternion quat = Quaternion.FromToRotation(Vector3.up, normal);
                    if (transform.rotation != quat)
                    {
                        transform.rotation = quat;
                        EState = SpiderState.DOWN;
                    }
                }
            }
            if (EState == SpiderState.DOWN)
            {
                if (Physics.Raycast(transform.position,
                     -transform.right,
                      out hit, 0.01f))
                {
                    if (hit.distance >= 0.01)
                        transform.position = hit.point;

                    Vector3 normal = hit.normal;
                    Quaternion quat = Quaternion.FromToRotation(Vector3.up, normal);
                    if (transform.rotation != quat)
                    {
                        transform.rotation = quat;
                        EState = SpiderState.UP;
                    }
                }
            }

            //Debug.Log(transform.right);
            rb.MovePosition(-transform.right * 0.05f + transform.position);
        }

        if(EState==SpiderState.ROTATE)
        {

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, 
            (transform.right * Direction) + (-transform.up));
        Gizmos.DrawRay(transform.position + transform.up,
            -transform.right);
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ShadowObject")
        {
            rb.isKinematic = false;
        }
    }
}
