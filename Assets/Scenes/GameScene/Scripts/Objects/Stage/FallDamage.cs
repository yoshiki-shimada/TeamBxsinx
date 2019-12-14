using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.damage(1f);
            player.ReSpawn(GameObject.FindGameObjectWithTag("ReSpawn").transform.position);
        }
    }
}
