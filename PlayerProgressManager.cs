using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProgressManager : MonoBehaviour
{
    [SerializeField] LevelState levelState;
    [SerializeField] Wallet wallet;
    [SerializeField] Turret turret;
    [SerializeField] UIMainMenu mainMenu;

    private void Awake()
    {
        Load();

        levelState.Passed.AddListener(Save);
        levelState.Passed.AddListener(SetNextLevel);
        mainMenu.QuitGame.AddListener(Save);
        mainMenu.StartPlay.AddListener(Save);
    }

    private void OnDestroy()
    {
        levelState.Passed.RemoveListener(Save);
        levelState.Passed.RemoveListener(SetNextLevel);
        mainMenu.QuitGame.RemoveListener(Save);
        mainMenu.StartPlay.RemoveListener(Save);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1) == true)
        {
            ResetProgress();
        }
    }

    public void Save()
    {
        levelState.Save();
        wallet.Save();
        turret.Save();
        mainMenu.Save();
    }

    private void Load()
    {
        levelState.Load();
        wallet.Load();
        turret.Load();
        mainMenu.Load();                
    }

    private void ResetProgress()
    {
        levelState.ResetProgress();
        wallet.ResetProgress();
        turret.ResetProgress();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SetNextLevel()
    {
        levelState.currentLevel++;

    }
}
