using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonExpPickup : MonoBehaviour
{
    public int xpAmount = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            DungeonPlayerStats.instance.GetXP(xpAmount);

            Destroy(gameObject);

            DungeonUIController.instance.UpdateUI();
        }
    }
}
