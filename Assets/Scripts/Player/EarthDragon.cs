using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthDragon : Dragon
{
    protected override void Start()
    {
        base.Start();
        projectilesSpawnPoints[0].SetActive(true);
        projectilesSpawnPoints[1].SetActive(true);
        projectilesSpawnPoints[2].SetActive(true);
    }
    
    protected override void TriggerUpgrade(int lvl)
    {
        if (lvl == 2)
        {
            damage += 2;
        }
        else if (lvl == 3)
        {
            damage += 1;
            attackSpeed -= 0.05f;
        }
        else if (lvl == 4)
        {
            attackSpeed -= 0.1f;
        }
        else if (lvl == 5)
        {
            projectilesSpawnPoints[0].SetActive(false);
            projectilesSpawnPoints[1].SetActive(true);
            projectilesSpawnPoints[2].SetActive(true);
        }
        else if (lvl == 6)
        {
            damage += 1;
            attackSpeed -= 0.05f;
        }
        else if (lvl == 7)
        {
            attackSpeed -= 0.05f;
            damage += 1;
        }
        else if (lvl == 8)
        {
            damage += 1;
        }
        else if (lvl == 9)
        {
            attackSpeed -= 0.1f;
        }
        else if (lvl == 10)
        {
            projectilesSpawnPoints[0].SetActive(true);
        }
    }
    
    protected override void ShootProjectile()
    {
        base.ShootProjectile();
        
        foreach (Projectile proj in projectiles)
        {
            proj.PassParameters(damage, false, 2, false, 0);
            return;
        }
        
    }
}
