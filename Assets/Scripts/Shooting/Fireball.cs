using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile
{

    private float dmg;
    private float expRadius; // radius of an explosion

    private bool explodeAtDeath = false;

    public GameObject explosionPrefab;


    // when creating projectile, pass parameters abut it
    public override void PassParameters(float damage, bool fireballExplode, float explosionRadius, bool lightChain, int chainAmount)
    {
        dmg = damage;
        explodeAtDeath = fireballExplode;
        expRadius = explosionRadius;

    }
    
    // what to do with projectile when it hits an enemy
    protected override void OnProjectileEnemyHit(Collider2D coll)
    {
        Debug.Log("Fireball hit enemy " + coll.name);
        Damage damage = new Damage()
        {
            damageAmmount = dmg,
            knockBack = 0,
            origin = transform.position
            
        };

        /*if (igniteEnemies)
        {
            GameObject enemyHit = coll.gameObject;
            GameObject currentBurn =
                Instantiate(burn, enemyHit.transform.position, Quaternion.identity, enemyHit.transform);
            // pass paremeters to burn added to enemy
            currentBurn.GetComponent<Burn>().CalculateBurnDamage(damage, igniteEfficieny);
        }*/
    
        coll.SendMessage("RecieveDamage", damage);
        if (explodeAtDeath is true)
        {
            Explode();
        }
        Destroy(gameObject);
    }
    
    
    // what to do with projectile when it's lifetime ends
    /*protected override void OnProjectileEnd()
    {
        if (explodeAtDeath is true)
        {
            Explode();
        }
        Destroy(gameObject);
    }*/

    
    // what to do with projectile when it hits the wall
    /*protected override void OnProjectileWallHit(Collider2D coll)
    {
        if (explodeAtDeath is true)
        {
            Explode();
            
        }
        else
        {
            
            Vector3 offset = effectSpawnPoint.position - transform.position;
            HandleParticles(hitWallEffect, false, hitWallEffect.GetComponent<ParticleSystem>().main.duration, offset=offset); 
            
        }
        Destroy(gameObject);
    }*/

    // create explosion game object and pass parameters
    private void Explode()
    {
        Debug.Log("Exploding");
        GameObject currentExplosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        
        // pass parameters about explosion to newly created explosion object
        currentExplosion.GetComponent<FireballExplosion>().PassParameters(dmg*1.5f, expRadius);
    }
}
