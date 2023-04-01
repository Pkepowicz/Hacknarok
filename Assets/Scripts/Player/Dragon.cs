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
    }


}
