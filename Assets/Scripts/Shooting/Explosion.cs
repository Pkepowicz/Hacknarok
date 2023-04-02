using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Explosion : Collidable
{
    // animation clip of explosion
    public AnimationClip animClip;
    
    protected float explosionDamage;
    protected float knockback;

   
    
    protected void Start()
    {
        // destroy this gameObject at the end of its animation
        Destroy(gameObject, animClip.length);
    }
    
    public void PassParameters(float damage, float radius)
    {
        explosionDamage = damage;
        gameObject.transform.localScale = new Vector3(1f * radius, 1f * radius, 1);
    }
}