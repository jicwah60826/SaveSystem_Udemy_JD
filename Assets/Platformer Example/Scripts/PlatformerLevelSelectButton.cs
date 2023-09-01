using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformerLevelSelectButton : MonoBehaviour
{
    public string sceneToLoad;

    public bool isLocked;
    public GameObject lockedDisplay;

    private void Start()
    {
        lockedDisplay.SetActive(isLocked);
    }

    public void SelectLevel()
    {
        if (PlatformerLevelSelect.instance.levelLoading == false && isLocked == false)
        {
            PlatformerLevelSelect.instance.StartLevelLoad(sceneToLoad);
        }
    }
}
