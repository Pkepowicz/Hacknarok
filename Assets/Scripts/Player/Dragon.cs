using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Dragon : Fighter
{
    public string dragonType;
    
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    protected float damage = 1, attackSpeed = 1; // time between attacks, 0.5 means 0.5 time between each attack

    private List<GameObject> projectilesSpawnPoints;
    
    [SerializeField] private GameObject spawnPointParent;

    protected override void Start()
    {
        base.Start();
        Debug.Log(spawnPointParent.transform.childCount);
        for (int i = 0; i < spawnPointParent.transform.childCount; i++)
        {
            projectilesSpawnPoints.Add(spawnPointParent.transform.GetChild((i)).gameObject);
        }
        
        Debug.Log("Projectile spawn points found: " + projectilesSpawnPoints.Count);
    }


    public IEnumerator Shoot()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(attackSpeed);
            ShootProjectile();
        }
    }

    protected void ShootProjectile()
    {
        Debug.Log(dragonType + " dragon just fired a projectile");

        foreach (GameObject point in projectilesSpawnPoints)
        {
            //Instantiate(projectilePrefab, point.transform.position, Quaternion.identity);
            Debug.Log("shoot");
        }
        
    }


}
