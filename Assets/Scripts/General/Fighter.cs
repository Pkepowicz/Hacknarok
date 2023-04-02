using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Collidable
{
    // public fields
    public float hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.02f;

    // Immunity
    protected float immuneTime = 0.1f;
    protected float lastImmune;

    // Push
    protected Vector3 pushDirection;

    // All fighters recieve damage / die
    protected virtual void RecieveDamage(Damage dmg)
    {
        if(Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmmount;
            //GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);

            if (hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {
        Debug.Log("Not Implemented");
    }
}