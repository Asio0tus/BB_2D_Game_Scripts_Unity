using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    
    private int coinAmount;

    public int CoinAmount => coinAmount;

    public void Payment(int cost)
    {

    }

    public void GetCoin(int cost)
    {
        coinAmount += cost;

        Debug.Log(coinAmount);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("CoinAmount", coinAmount);
    }

    public void Load()
    {
        coinAmount = PlayerPrefs.GetInt("CoinAmount", 0);
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
    }

}
