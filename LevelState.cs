using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelState : MonoBehaviour
{
    [SerializeField] private Cart cart;
    [SerializeField] private StoneSpawner stoneSpawner;
    
    [Space(5)]
    public UnityEvent Passed;
    public UnityEvent Defeat;

    private float timer;
    private bool checkPassed;

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
}
