using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPlayerStats : MonoBehaviour
{
    public static DungeonPlayerStats instance;

    private void Awake()
    {
        instance = this;
    }

    public int strength;
    public int defence;

    public int level;
    public int currentXP;
    public int xpToLevel;

    public int maxHP;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            GetXP(3);
        }
    }

    public void GetXP(int xpGet)
    {
        currentXP += xpGet;

        if(currentXP >= xpToLevel)
        {
            LevelUp();
        }

        DungeonUIController.instance.UpdateUI();
    }

    public void LevelUp()
    {
        currentXP -= xpToLevel;

        level++;

        xpToLevel = Mathf.RoundToInt(xpToLevel * 1.2f);

        strength++;
        defence++;
        maxHP++;
        DungeonPlayer.instance.currentHealth++;

        DungeonUIController.instance.UpdateUI();
    }
}
