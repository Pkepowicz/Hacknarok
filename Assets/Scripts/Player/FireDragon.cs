using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDragon : Dragon
{

    private bool explodingShoots = true;
    private int explodingCooldown = 2; // how many shoots before the next explosion
    private int explodingCounter = 0; // how many shoots have been done since the last explosion

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
            explodingShoots = true;
            Debug.Log("Now hits will explode");
        }
        else if (lvl == 6)
        {
            damage += 1;
            attackSpeed -= 0.05f;
        }
        else if (lvl == 7)
        {
            explodingCooldown -= 1;
        }
        else if (lvl == 8)
        {
            explodingCooldown -= 1;
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
            explodingCooldown -= 1;
        }
    }

    protected override void ShootProjectile()
    {
        base.ShootProjectile();
        if (explodingShoots)
        {
            explodingCounter++;
            if (explodingCounter >= explodingCooldown)
            {
                explodingCounter = 0;
                foreach (Projectile proj in projectiles)
                {
                    proj.PassParameters(damage, true, 2, false, 0);
                    return;
                }
            }
        }
        
        foreach (Projectile proj in projectiles)
        {
            proj.PassParameters(damage, false, 2, false, 0);
            return;
        }
        
    }
    
    
}
