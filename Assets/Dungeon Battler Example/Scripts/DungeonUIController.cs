using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DungeonUIController : MonoBehaviour
{
    public static DungeonUIController instance;

    private void Awake()
    {
        instance = this;

        fadeScreen.gameObject.SetActive(true);
    }

    public Image fadeScreen;

    public float fadeSpeed = 5f;

    private bool fadeToBlack, fadeFromBlack;

    public GameObject gameOverScreen, pauseScreen;

    public string mainMenuScene;

    public Slider xpSlider, hpSlider;
    public TMP_Text xpText, levelText, strengthText, defenceText, hpText, weaponText, weaponAttackText;

    // Start is called before the first frame update
    void Start()
    {
        StartFadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
        }

        if(fadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
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

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void PauseUnpause()
    {
        if(pauseScreen.activeSelf == false)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;

        } else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void UpdateUI()
    {
        xpSlider.maxValue = DungeonPlayerStats.instance.xpToLevel;
        xpSlider.value = DungeonPlayerStats.instance.currentXP;
        xpText.text = "EXP: " + xpSlider.value + "/" + xpSlider.maxValue;
        levelText.text = "Level: " + DungeonPlayerStats.instance.level;
        strengthText.text = "Strength: " + DungeonPlayerStats.instance.strength;
        defenceText.text = "Defence: " + DungeonPlayerStats.instance.defence;

        hpSlider.maxValue = DungeonPlayerStats.instance.maxHP;
        hpSlider.value = DungeonPlayer.instance.currentHealth;
        hpText.text = "HP: " + hpSlider.value + "/" + hpSlider.maxValue;
        weaponText.text = "Weapon: " + DungeonPlayer.instance.weapon.currentWeapon;
        weaponAttackText.text = "(+" + DungeonPlayer.instance.weapon.activeWeaponInfo.damageAmount + " Attack)";
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
        Time.timeScale = 1f;
    }
}
