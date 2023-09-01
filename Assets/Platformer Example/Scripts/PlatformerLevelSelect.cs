using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlatformerLevelSelect : MonoBehaviour
{
    public static PlatformerLevelSelect instance;
    private void Awake()
    {
        instance = this;
    }

    public float fadeSpeed = 2f;
    private bool fadeSceneOut, fadeSceneIn;

    public Image cover;

    public bool levelLoading;

    public int coinCount;
    public TMP_Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        StartFadeIn();

        coinText.text = "Coins: " + coinCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeSceneIn)
        {
            cover.color = new Color(cover.color.r, cover.color.g, cover.color.b, Mathf.MoveTowards(cover.color.a, 0f, fadeSpeed * Time.deltaTime));
        }
        if(fadeSceneOut)
        {
            cover.color = new Color(cover.color.r, cover.color.g, cover.color.b, Mathf.MoveTowards(cover.color.a, 1f, fadeSpeed * Time.deltaTime));
        }
    }

    public void StartFadeIn()
    {
        fadeSceneOut = false;
        fadeSceneIn = true;
    }

    public void StartFadeOut()
    {
        fadeSceneOut = true;
        fadeSceneIn = false;

    }

    public void StartLevelLoad(string levelToLoad)
    {
        StartCoroutine(LoadCo(levelToLoad));
    }

    IEnumerator LoadCo(string levelToLoad)
    {
        levelLoading = true;

        StartFadeOut();

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelToLoad);
    }
}
