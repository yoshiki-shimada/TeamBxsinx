using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.damage(3f);
            player.ReSpawn(GameObject.FindGameObjectWithTag("ReSpawn").transform.position);
        }
    }
}
