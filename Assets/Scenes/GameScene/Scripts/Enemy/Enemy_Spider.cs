using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SpiderState
{
    TOP,
    LEFT,
    BOTTOM,
    RIGHT,
    ROTATE,
}

public class Enemy_Spider : MonoBehaviour
{
    SphereCollider col;
    Rigidbody rb;
    int Direction = 1;
    SpiderState EState = SpiderState.TOP;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (EState == SpiderState.TOP)
        {
            if (Physics.Raycast(transform.position,
                (transform.right * Direction) + (-transform.up),
                out hit, 1))
            {
                if (hit.distance >= 0.05)
                    transform.position = hit.point;

                Vector3 normal = hit.normal;
                Quaternion quat = Quaternion.FromToRotation(Vector3.up, normal);
                if (transform.rotation != quat)
                {
                    transform.rotation = quat;
                    EState = SpiderState.LEFT;
                }
            }
        }
        else if (EState == SpiderState.LEFT)
        {
            if (Physics.Raycast(transform.position,
                 -transform.right,
                  out hit, 1))
            {
                if (hit.distance >= 0.05)
                    transform.position = hit.point;

                Vector3 normal = hit.normal;
                Quaternion quat = Quaternion.FromToRotation(Vector3.up, normal);
                if (transform.rotation != quat)
                {
                    transform.rotation = quat;
                    EState = SpiderState.TOP;
                }
            }
        }

        if (EState != SpiderState.ROTATE)
        {
            rb.AddForce(-transform.right);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, 
            (transform.right * Direction) + (-transform.up));
        Gizmos.DrawRay(transform.position,
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
