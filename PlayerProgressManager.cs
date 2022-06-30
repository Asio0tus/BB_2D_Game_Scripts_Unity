using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProgressManager : MonoBehaviour
{
    [SerializeField] LevelState levelState;
    [SerializeField] Wallet wallet;
    [SerializeField] Turret turret;


    private void Awake()
    {
        Load();

        levelState.Passed.AddListener(Save);
        levelState.Passed.AddListener(SetNextLevel);
    }

    private void OnDestroy()
    {
        levelState.Passed.RemoveListener(Save);
        levelState.Passed.RemoveListener(SetNextLevel);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1) == true)
        {
            ResetProgress();
        }
    }

    private void Save()
    {
        levelState.Save();
        wallet.Save();
        turret.Save();

    }

    private void Load()
    {
        levelState.Load();
        wallet.Load();
        turret.Load();

        Debug.Log("load");
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
