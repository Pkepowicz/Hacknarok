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

    public List<GameObject> projectilesSpawnPoints;
    
    [SerializeField] public GameObject spawnPointParent;

    protected override void Start()
    {
        base.Start();
        for (int i = 0; i < spawnPointParent.transform.childCount; i++)
        {
            projectilesSpawnPoints.Add(spawnPointParent.transform.GetChild(i).gameObject);
        }
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
        foreach (GameObject point in projectilesSpawnPoints)
        {
            Instantiate(projectilePrefab, point.transform.position, Quaternion.identity);
        }
        
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.CompareTag("Enemy"))
        {
            Debug.Log("You got hit by an emeny, you should take damage");
        }

    }


}
