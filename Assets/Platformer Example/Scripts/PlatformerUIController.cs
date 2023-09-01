using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlatformerUIController : MonoBehaviour
{
    public static PlatformerUIController instance;

    private void Awake()
    {
        instance = this;
    }

    public TMP_Text coinText;

    public void UpdateCoinText(int coinAmount)
    {
        coinText.text = "Coins: " + coinAmount;
    }
}
