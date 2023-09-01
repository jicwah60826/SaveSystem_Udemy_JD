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
}
