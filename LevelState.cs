using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelState : MonoBehaviour
{
    [SerializeField] private Cart cart;
    
    [Space(5)]
    public UnityEvent Passed;
    public UnityEvent Defeat;

    private void Awake()
    {
        cart.CollisionStone.AddListener(OnCartCollisionStone);
    }

    private void OnDestroy()
    {
        cart.CollisionStone.RemoveListener(OnCartCollisionStone);
    }

    private void OnCartCollisionStone()
    {
        Defeat.Invoke();
    }
}
