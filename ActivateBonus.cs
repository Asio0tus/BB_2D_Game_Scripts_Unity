using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBonus : MonoBehaviour
{
    [SerializeField] private float timerBonus;
    [SerializeField] private PolygonCollider2D turret;    
    [SerializeField] private GameObject freezeImage;
    [SerializeField] private GameObject shieldImage;

    private float timer;
    private bool freezeBonusOn;
    private bool immortalBonusOn;

    public bool ImmortalBonusOn => immortalBonusOn;

    private Stone[] stone;

    private void Awake()
    {
        freezeImage.SetActive(false);
        shieldImage.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bonus bonus = collision.transform.root.GetComponent<Bonus>();

        if (bonus != null)
        {
            int bonusNumber = Random.Range(1, 3);

            timer = 0;

            if (bonusNumber == 1) freezeBonusOn = true;
            if (bonusNumber == 2) immortalBonusOn = true;

        }
    }

    
    private void Update()
    {
        if(freezeBonusOn == true || immortalBonusOn == true)
        {
            timer += Time.deltaTime;
        }

        if(freezeBonusOn == true)
        {
            if(timer <= timerBonus)
            {
                FreezeBonusActivate();
            }
            else
            {
                FreezeBonusDeactivate();
                freezeBonusOn = false;
            }
        }

        if (immortalBonusOn == true)
        {
            if (timer <= timerBonus)
            {
                ImmortalBonusActivate();
            }
            else
            {
                ImmortalBonusDeactivate();
                immortalBonusOn = false;
            }
        }

    }

    private void FreezeBonusActivate()
    {
        stone = FindObjectsOfType<Stone>();

        for (int i = 0; i < stone.Length; i++)
        {
            stone[i].GetComponent<StoneMovement>().enabled = false;
        }

        freezeImage.SetActive(true);
    }

    private void FreezeBonusDeactivate()
    {
        for (int i = 0; i < stone.Length; i++)
        {
            stone[i].GetComponent<StoneMovement>().enabled = true;
        }

        stone = null;
        freezeImage.SetActive(false);
        timer = 0;
    }

    private void ImmortalBonusActivate()
    {
        shieldImage.SetActive(true);
    }

    private void ImmortalBonusDeactivate()
    {
        shieldImage.SetActive(false);
        timer = 0;
    }
}
