using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject cart;
    [SerializeField] private GameObject stoneSpawner;
    [SerializeField] private GameObject canvasGame;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject manager;

    private void Awake()
    {
        cart.SetActive(false);
        stoneSpawner.SetActive(false);
        canvasGame.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        cart.SetActive(true);
        stoneSpawner.SetActive(true);
        canvasGame.SetActive(true);
        mainMenu.SetActive(false);
    }
    
    public void SetActiveMainMenu()
    {
        cart.SetActive(false);
        stoneSpawner.SetActive(false);
        canvasGame.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void EndLevel()
    {
        cart.SetActive(false);
        stoneSpawner.SetActive(false);
        canvasGame.SetActive(false);
        manager.SetActive(false);
    }

    public void RestartLevel()
    {
        cart.SetActive(true);
        stoneSpawner.SetActive(true);
        canvasGame.SetActive(true);
        manager.SetActive(true);
    }
}
