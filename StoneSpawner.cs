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
    [SerializeField] private int stoneAmountDefault;
    [SerializeField] [Range(0.0f, 1.0f)] private float minHitpointsPercentage;
    [SerializeField] private int maxHitpointsDefault;
    [SerializeField] private LevelState levelState;

    [SerializeField] private UIProgressPanel progressPanel;

    [Space(10)] public UnityEvent Completed;

    private Color32[] stoneColor;

    private int stoneAmount;
    private float timer;
    private int amountSpawned;
    private int stoneMaxHitpoint;
    private int stoneMinHitpoint;

    float posZ;

    private float allStoneHP;

    public int StoneAmount => stoneAmount;
    public int AmountSpawned => amountSpawned;
    public float AllStoneHP => allStoneHP;
    public int StoneMaxHitpoint => stoneMaxHitpoint;

    private void Start()
    {
        //int damagePerSecond = (int)((turret.Damage * turret.ProjectileAmount) * (1 / turret.FireRate));

        stoneMaxHitpoint = maxHitpointsDefault + (levelState.currentLevel * 5);
        stoneMinHitpoint = stoneMaxHitpoint / 2;

        timer = spawnRate;

        stoneAmount = stoneAmountDefault + levelState.CurrentLevel;

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

        allStoneHP += Mathf.Pow(2, stone.getSize);

        amountSpawned++;

        progressPanel.FillStepMath();
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
