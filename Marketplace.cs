using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marketplace : MonoBehaviour
{
    [SerializeField] private GameObject market;
    [SerializeField] private GameObject fireRateButton;
    [SerializeField] private Wallet wallet;
    [SerializeField] private Turret turret;
    [SerializeField] private Text costProjectileAmountText;
    [SerializeField] private Text costProjectileFireRateText;
    [SerializeField] private Text costProjectileDamageText;
    [SerializeField] private Text coinAmountInWalletText;

    [SerializeField] private GameObject cart;
    [SerializeField] private GameObject stoneSpawner;
    [SerializeField] private GameObject canvasGame;    
    
    private int costProjectileAmount;
    private float costProjectileFireRate;
    private int costProjectileDamage;

    private void Awake()
    {
        market.SetActive(false);

        if(turret.FireRate <= 0.1)
        {
            fireRateButton.SetActive(false);
        }
       
    }

    public void SetCostOnMarket()
    {
        costProjectileAmount = turret.ProjectileAmount * 10;
        costProjectileDamage = turret.Damage * 10;
        costProjectileFireRate = (turret.FireRate - 1) * -100 / 2;

        costProjectileAmountText.text = costProjectileAmount.ToString();
        costProjectileDamageText.text = costProjectileDamage.ToString();
        costProjectileFireRateText.text = costProjectileFireRate.ToString();
        coinAmountInWalletText.text = wallet.CoinAmount.ToString();

        if (turret.FireRate <= 0.1)
        {
            fireRateButton.SetActive(false);
        }

    }

    public void BuyProjectileAmount()
    {
        if (wallet.CoinAmount >= costProjectileAmount)
        {
            wallet.Payment(costProjectileAmount);
            turret.BuyUpgradeProjectileAmount();

            SetCostOnMarket();
        }

        else return;
    }

    public void BuyProjectileDamage()
    {
        if (wallet.CoinAmount >= costProjectileDamage)
        {
            wallet.Payment(costProjectileDamage);
            turret.BuyUpgradeProjectileDamage();

            SetCostOnMarket();
        }

        else return;
    }

    public void BuyProjectileFireRate()
    {
        if (wallet.CoinAmount >= costProjectileFireRate)
        {
            wallet.Payment((int)costProjectileFireRate);
            turret.BuyUpgradeProjectileFireRate();

            SetCostOnMarket();
        }

        else return;
    }

    public void SetActiveMarket()
    {
        cart.SetActive(false);
        stoneSpawner.SetActive(false);
        canvasGame.SetActive(false);
        market.SetActive(true);
    }


}
