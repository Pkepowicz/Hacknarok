using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Dragon : Fighter
{
    public string dragonType;

    [SerializeField]
    private GameObject projectilePrefab;

    protected float damage;
    protected float attackSpeed; // time between attacks, 0.5 means 0.5 time between each attack

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackSpeed);
            // Shoot projectile
        }
    }

    protected void ShootProjectile()
    {
        
    }


}
