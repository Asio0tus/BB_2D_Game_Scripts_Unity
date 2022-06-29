using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    [SerializeField] private Text coinAmountText;
    [SerializeField] private Wallet wallet;

    private void Update()
    {
        DrawCoinAmount();
    }

    public void DrawCoinAmount()
    {
        coinAmountText.text = wallet.CoinAmount.ToString();
    }
}
