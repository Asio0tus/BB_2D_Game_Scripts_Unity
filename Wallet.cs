using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int coinCost;
    private int coinAmount;

    public int CoinAmount => coinAmount;

    public void Payment(int cost)
    {
        coinAmount -= cost;
    }

    public void GetCoin(int cost)
    {
        coinAmount += cost;

        Debug.Log(coinAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Coin coin = collision.transform.root.GetComponent<Coin>();               

        if (coin != null)
        {
            GetCoin(coinCost);
        }
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
