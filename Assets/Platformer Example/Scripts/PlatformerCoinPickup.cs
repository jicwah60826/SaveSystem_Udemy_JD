using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerCoinPickup : MonoBehaviour
{
    public GameObject pickupEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlatformerLevelManager.instance.AddCoin();

            Destroy(gameObject);

            if(pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, transform.rotation);
            }
        }
    }
}
