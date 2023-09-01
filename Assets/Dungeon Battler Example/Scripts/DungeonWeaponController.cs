using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonWeaponController : MonoBehaviour
{
    [System.Serializable]
    public enum weaponType { Sword, Axe, Hammer };
    public weaponType currentWeapon;
    [HideInInspector]
    public WeaponInfo activeWeaponInfo;
    public List<WeaponInfo> weaponDetails;

    public GameObject sword, axe, hammer;

    public Animator anim;

    public float attackPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetUp()
    {
        //Call the new weapon method and pass in the argument for the current weapon from the data in the save file on disk
        NewWeapon(SaveSystem.instance.activeSave.currentWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewWeapon(weaponType newWeapon)
    {
        sword.SetActive(false);
        axe.SetActive(false);
        hammer.SetActive(false);

        switch(newWeapon)
        {
            case weaponType.Sword:

                sword.SetActive(true);
                

                break;

            case weaponType.Axe:

                axe.SetActive(true);

                break;

            case weaponType.Hammer:

                hammer.SetActive(true);

                break;
        }

        currentWeapon = newWeapon;

        activeWeaponInfo = null;
        foreach(WeaponInfo info in weaponDetails)
        {
            if(info.weaponType == currentWeapon)
            {
                activeWeaponInfo = info;
            }
        }
        if (activeWeaponInfo == null)
        {
            Debug.LogError("Can't find weapon info");
        }
        else
        {

            attackPower = activeWeaponInfo.damageAmount + DungeonPlayerStats.instance.strength;
        }

        DungeonUIController.instance.UpdateUI();

        //Update the SaveSystem class with the new weapon type
        SaveSystem.instance.activeSave.currentWeapon = newWeapon;
    }

    public void DoAttack()
    {
        anim.SetTrigger("attack");
    }
}

[System.Serializable]
public class WeaponInfo
{
    public DungeonWeaponController.weaponType weaponType;
    public float damageAmount;
}
