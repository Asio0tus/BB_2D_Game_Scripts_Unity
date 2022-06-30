using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float fireRate;
    [SerializeField] private int projectileAmount;
    [SerializeField] private float projectileInterval;
    [SerializeField] private int damage;

    private float timer;

    public int Damage => damage;
    public int ProjectileAmount => projectileAmount;
    public float FireRate => fireRate;

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void SpawnProjectile()
    {
        float startPosX = shootPoint.position.x - projectileInterval * (projectileAmount - 1) * 0.5f;

        for(int i = 0; i < projectileAmount; i++)
        {
            Projectile projectile = Instantiate(projectilePrefab, new Vector3(startPosX + i * projectileInterval, shootPoint.position.y, shootPoint.position.z), Quaternion.identity);
            projectile.SetDamage(damage);
        }
        
    }

    public void Fire()
    {
        if(timer >= fireRate)
        {
            SpawnProjectile();

            timer = 0;
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("ProjectileAmount", projectileAmount);
        PlayerPrefs.SetInt("Damage", damage);
        PlayerPrefs.SetFloat("FireRate", fireRate);
    }

    public void Load()
    {
        projectileAmount = PlayerPrefs.GetInt("ProjectileAmount", 1);
        damage = PlayerPrefs.GetInt("Damage", 1);
        fireRate = PlayerPrefs.GetFloat("FireRate", 0.2f);
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
    }
}
