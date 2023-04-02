using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : Projectile
{
    private float dmg = 1;

    private bool chain = false;
    private int chainCount = 5;
    
    public GameObject ChainLightningEffect;
    public GameObject beenStruck;
    
    public override void PassParameters(float damage, bool fireballExplode, float explosionRadius, bool lightChain, int chainAmount)
    {
        dmg = damage;
        chain = lightChain;
        chainCount = chainAmount;

    }
    
    protected override void OnProjectileEnemyHit(Collider2D coll)
    {
        Debug.Log("Lightning bolt hit an enemy " + coll.name);
        Damage damage = new Damage()
        {
            damageAmmount = dmg,
            knockBack = 0,
            origin = transform.position
            
        };

        coll.SendMessage("RecieveDamage", damage);
        Instantiate(beenStruck, coll.transform);
        Instantiate(ChainLightningEffect, coll.transform.position, Quaternion.identity, coll.transform);
        /*if (explodeAtDeath is true)
        {
            Explode();
        }*/
        Destroy(gameObject);
    }
}
