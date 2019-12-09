using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spider : MonoBehaviour
{
    CapsuleCollider Collider;
    Rigidbody rb;
    Transform Balance;
    // Start is called before the first frame update
    void Start()
    {
        Collider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        Balance = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        // Transformの真下の地形の法線を調べる
        if (Physics.Raycast(
                    Balance.position,
                    -transform.up,
                    out hit,
                    float.PositiveInfinity))
        {
            Vector3 vec = Vector3.ProjectOnPlane(transform.position, hit.normal);
            transform.position = vec*3;
            
            // 傾きの差を求める
            Quaternion q = Quaternion.FromToRotation(
                        transform.up,
                        hit.normal);

            // 自分を回転させる
            transform.rotation *= q;

            // 地面から一定距離離れていたら落下
           /* if (hit.distance > 0.05f)
            {
                transform.position =
                    transform.position +
                    (-transform.up * Physics.gravity.magnitude * Time.fixedDeltaTime);
            }*/
        }
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
