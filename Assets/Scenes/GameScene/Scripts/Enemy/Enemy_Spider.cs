using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spider : MonoBehaviour
{
    SphereCollider Collider;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Collider = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ShadowObject")
        {
            Collider.isTrigger = false;
            rb.isKinematic = false;
        }
    }
}
