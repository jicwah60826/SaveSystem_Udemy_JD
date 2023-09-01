using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DungeonMainMenu : MonoBehaviour
{
    public string firstLevel;

    public Image fadeScreen;

    public float fadeSpeed = 5f;

    private bool fadeToBlack, fadeFromBlack;

    private void Start()
    {
        StartFadeFromBlack();
    }

    void Update()
    {
        if (fadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
        }

        if (fadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
        }
    }

    public void StartFadeToBlack()
    {
        fadeToBlack = true;
        fadeFromBlack = false;
    }

    public void StartFadeFromBlack()
    {
        fadeToBlack = false;
        fadeFromBlack = true;
    }

    public void StartGame()
    {
        StartCoroutine(StartCo());
    }

    IEnumerator StartCo()
    {
        StartFadeToBlack();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(firstLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Continue()
    {
        StartCoroutine(ContinueCo());
    }

    IEnumerator ContinueCo()
    {
        StartFadeToBlack();
        yield return new WaitForSeconds(1f);
    }
}
