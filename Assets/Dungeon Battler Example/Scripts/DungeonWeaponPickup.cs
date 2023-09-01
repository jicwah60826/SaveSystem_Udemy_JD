using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonWeaponPickup : MonoBehaviour
{
    public DungeonWeaponController.weaponType weaponType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            DungeonPlayer.instance.weapon.NewWeapon(weaponType);

            Destroy(gameObject);
        }
    }
}
