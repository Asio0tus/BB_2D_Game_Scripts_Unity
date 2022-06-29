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

    [Space(10)] public UnityEvent Completed;

    private Color32[] stoneColor;

    private float timer;
    private int amountSpawned;
    private int stoneMaxHitpoint;
    private int stoneMinHitpoint;

    float posZ;


    private void Start()
    {
        int damagePerSecond = (int)((turret.Damage * turret.ProjectileAmount) * (1 / turret.FireRate));

        stoneMaxHitpoint = (int)(damagePerSecond * maxHitpointsRate);
        stoneMinHitpoint = (int)(stoneMaxHitpoint * minHitpointsPercentage);

        timer = spawnRate;
        
        LoadColor();        
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnRate)
        {
            Spawn();

            posZ += 0.001f;

            timer = 0;
        }

        if(amountSpawned == stoneAmount)
        {
            enabled = false;
            posZ = 0;

            Completed.Invoke();
        }
    }

    private void Spawn()
    {       

        Stone stone = Instantiate(stonePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        stone.SetSize((Stone.Size) Random.Range(1, 4));
        stone.maxHitPoints = Random.Range(stoneMinHitpoint, stoneMaxHitpoint + 1);
        stone.GetComponentInChildren<SpriteRenderer>().color = stoneColor[Random.Range(0, 5)];
        stone.transform.position += new Vector3(0, 0, posZ);

        amountSpawned++;
    }

    private void LoadColor()
    {
        stoneColor = new Color32[5];

        stoneColor[0] = new Color32(200, 97, 97, 255);
        stoneColor[1] = new Color32(97, 113, 200, 255);
        stoneColor[2] = new Color32(97, 200, 114, 255);
        stoneColor[3] = new Color32(226, 215, 78, 255);
        stoneColor[4] = new Color32(217, 132, 66, 255);

    }
}
