using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveData
{
    public int strength, defense;
    public int level, currentExp, expToLevel;
    public int maxHP, currentHP;
    public DungeonWeaponController.weaponType curentWeapon;
    public string currentLevel;
}