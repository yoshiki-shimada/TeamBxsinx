using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spider_Head : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            collision.rigidbody.AddForce(
                (-collision.transform.right + collision.transform.up) * 1.5f,
                ForceMode.VelocityChange);
            collision.transform.GetComponent<Player>().damage(1f);
        }

    }
}
