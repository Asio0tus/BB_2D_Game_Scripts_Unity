using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject cart;
    [SerializeField] private GameObject stoneSpawner;
    [SerializeField] private GameObject canvasGame;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject manager;

    private int play;

    public UnityEvent QuitGame;
    public UnityEvent StartPlay;

    private void Awake()
    {
        if(play == 0)
        {
            cart.SetActive(false);
            stoneSpawner.SetActive(false);
            canvasGame.SetActive(false);
            mainMenu.SetActive(true);
        }
        else
        {
            cart.SetActive(true);
            stoneSpawner.SetActive(true);
            canvasGame.SetActive(true);
            mainMenu.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) == true)
        {
            SetActiveMainMenu();
        }
    }

    public void Exit()
    {
        play = 0;
        QuitGame.Invoke();
        Application.Quit();        
    }

    public void StartGame()
    {
        cart.SetActive(true);
        stoneSpawner.SetActive(true);
        canvasGame.SetActive(true);
        mainMenu.SetActive(false);

        play = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartPlay.Invoke();
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

    public void Save()
    {
        PlayerPrefs.SetInt("Play", play);
    }

    public void Load()
    {
        play = PlayerPrefs.GetInt("Play", 0);
                
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
    }
}
