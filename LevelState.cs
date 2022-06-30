using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelState : MonoBehaviour
{
    [SerializeField] private Cart cart;
    [SerializeField] private StoneSpawner stoneSpawner;
    
    [Space(5)]
    public UnityEvent Passed;
    public UnityEvent Defeat;

    private float timer;
    private bool checkPassed;
    [HideInInspector] public int currentLevel;

    public int CurrentLevel => currentLevel;

    private void Awake()
    {       
        cart.CollisionStone.AddListener(OnCartCollisionStone);
        stoneSpawner.Completed.AddListener(OnSpawnCompleted);
    }

    private void OnDestroy()
    {
        cart.CollisionStone.RemoveListener(OnCartCollisionStone);
        stoneSpawner.Completed.RemoveListener(OnSpawnCompleted);
    }

    private void OnCartCollisionStone()
    {
        Defeat.Invoke();
    }

    private void OnSpawnCompleted()
    {
        checkPassed = true;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > 0.5f)
        {
            if(checkPassed == true)
            {
                if (FindObjectsOfType<Stone>().Length == 0)
                {
                    Passed.Invoke();                                        
                }
            }

            timer = 0;
        }        
    }

    public void SetNextLevel()
    {
        currentLevel++;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);        
    }

    public void Load()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

        Debug.Log("loadlevelnumber");
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();        
    }


}
