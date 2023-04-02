using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBolt : Projectile
{

    public float dmg;
    public override void PassParameters(float damage, bool fireballExplode, float explosionRadius, bool lightChain, int chainAmount)
    {
        dmg = damage;
    }

    protected override void OnProjectileEnemyHit(Collider2D coll)
    {
        Debug.Log("Earthball hit enemy " + coll.name);
        Damage damage = new Damage()
        {
            damageAmmount = dmg,
            knockBack = 0,
            origin = transform.position
            
        };

        coll.SendMessage("RecieveDamage", damage);
        Destroy(gameObject);
    }
}
