using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoneSpawner : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate;

    [Header("Balance")]
    [SerializeField] private Turret turret;
    [SerializeField] private int stoneAmount;    
    [SerializeField] [Range(0.0f, 1.0f)] private float minHitpointsPercentage;
    [SerializeField] private float maxHitpointsRate;

    private float timer;
    private int amountSpawned;
    private int stoneMaxHitpoint;
    private int stoneMinHitpoint;

    private void Start()
    {
        int damagePerSecond = (int)((turret.Damage * turret.ProjectileAmount) * (1 / turret.FireRate));

        stoneMaxHitpoint = (int)(damagePerSecond * maxHitpointsRate);
        stoneMinHitpoint = (int)(stoneMaxHitpoint * minHitpointsPercentage);

        timer = spawnRate;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnRate)
        {
            Spawn();

            timer = 0;
        }

        if(amountSpawned == stoneAmount)
        {
            enabled = false;
        }
    }

    private void Spawn()
    {
        Stone stone = Instantiate(stonePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        stone.SetSize((Stone.Size) Random.Range(1, 4));
        stone.maxHitPoints = Random.Range(stoneMinHitpoint, stoneMaxHitpoint + 1);

        amountSpawned++;
    }


}
