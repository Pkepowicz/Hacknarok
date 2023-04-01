using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class Projectile : Collidable
{

    public float speed = 2.5f;
    public float lifetime = 5f; // Not sure if needed
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
        base.Start();
    }
    

    protected virtual void FixedUpdate()
    {
        // Go forward from launch offset until you exceed life time
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (Time.time - startTime > lifetime)
            OnProjectileEnd();
    }

    protected override void OnCollide(Collider2D coll)
    {
        // interact with enemy, and destroy itself
        if (coll.CompareTag("Enemy"))
        {
            Debug.Log("Collided with enemy");
            OnProjectileEnemyHit(coll);
            
        }

        else if (coll.CompareTag("Dragon"))
        {
            OnProjectilePlayerHit(coll);
        }

    }

    protected virtual void PassParameters(float damage, bool fireballExplode, float explosionRadius, bool lightChain, int chainAmount)
    {
        
    }

    // what to do with projectile when it hits an, e.g explode
    protected virtual void OnProjectileEnemyHit(Collider2D coll)
    {

    }

    // what to do with projectile when it expires, e.g explode
    protected virtual void OnProjectileEnd()
    {
        Destroy(gameObject);
    }

    protected virtual void OnProjectilePlayerHit(Collider2D coll)
    {
        //Destroy(gameObject);
    }
    
} 