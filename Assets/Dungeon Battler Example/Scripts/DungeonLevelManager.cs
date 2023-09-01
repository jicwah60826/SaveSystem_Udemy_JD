using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonLevelManager : MonoBehaviour
{
    public static DungeonLevelManager instance;
    private void Awake()
    {
        instance = this;
    }

    public string nextLevel;

    private bool isEnding;

    public void LeaveLevel()
    {
        if (isEnding == false)
        {
            isEnding = true;
            StartCoroutine(LeaveLevelCo());
        }
    }

    IEnumerator LeaveLevelCo()
    {
        DungeonUIController.instance.StartFadeToBlack();

        UpdateSaveSystem();

        yield return new WaitForSeconds(.5f);

        if (nextLevel != "")
        {
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void UpdateSaveSystem()
    {

        //create a reference to the DungeonPlayer script so that we can PULL data from this and inject into the Active Save class
        DungeonPlayerStats stats = DungeonPlayerStats.instance;

        // Set the Data in the save system class to the current data from the DungeonPlayerStats instance
        SaveSystem.instance.activeSave.strength = stats.strength;
        SaveSystem.instance.activeSave.defense = stats.defence;
        SaveSystem.instance.activeSave.level = stats.level;
        SaveSystem.instance.activeSave.currentExp = stats.currentXP;
        SaveSystem.instance.activeSave.expToLevel = stats.strength;
        SaveSystem.instance.activeSave.strength = stats.xpToLevel;
        SaveSystem.instance.activeSave.maxHP = stats.maxHP;

        // Set the current health in the save system class to the current health from the DungeonPlayer instance
        SaveSystem.instance.activeSave.currentHP = DungeonPlayer.instance.currentHealth;


    }
}
