using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormDragon : Dragon
{
    private bool chainignShots = false;
    private int chainingCooldown = 5; // how many shoots before the next explosion
    private int chainingCounter = 0; // how many shoots have been done since the last explosion

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
            chainignShots = true;
            Debug.Log("Now hits will explode");
        }
        else if (lvl == 6)
        {
            damage += 1;
            attackSpeed -= 0.05f;
        }
        else if (lvl == 7)
        {
            chainingCooldown -= 1;
        }
        else if (lvl == 8)
        {
            chainingCooldown -= 1;
            damage += 1;
        }
        else if (lvl == 9)
        {
            attackSpeed -= 0.1f;
        }
        else if (lvl == 10)
        {
            damage += 1;
            attackSpeed -= 0.05f;
            chainingCooldown -= 1;
        }
    }
    
    protected override void ShootProjectile()
    {
        base.ShootProjectile();
        if (chainignShots)
        {
            chainingCounter++;
            if (chainingCounter >= chainingCooldown)
            {
                chainingCounter = 0;
                foreach (Projectile proj in projectiles)
                {
                    proj.PassParameters(damage, false, 0, true, 4);
                    return;
                }
            }
        }
        
        foreach (Projectile proj in projectiles)
        {
            proj.PassParameters(damage, false, 0, false, 0);
            return;
        }
        
    }



}
