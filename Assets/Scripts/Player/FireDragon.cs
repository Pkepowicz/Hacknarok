using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDragon : Dragon
{

    private bool explodingShoots = false;
    private int explodingCooldown = 7; // how many shoots before the next explosion
    private int explodingCounter = 0; // how many shoots have been done since the last explosion

    protected override void TriggerUpgrade(int lvl)
    {
        if (lvl == 2)
        {
            
        }
        else if (lvl == 3)
        {
            
        }
        else if (lvl == 4)
        {
            
        }
        else if (lvl == 5)
        {
            
        }
        else if (lvl == 6)
        {
            
        }
        else if (lvl == 7)
        {
            
        }
        else if (lvl == 8)
        {
            
        }
        else if (lvl == 9)
        {
            
        }
        else if (lvl == 10)
        {
            
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
                    
                }
            }
        }
    }
    
    
}
