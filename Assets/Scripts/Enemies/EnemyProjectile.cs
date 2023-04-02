using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{ 
    public float damage = 1f;

    protected override void Start()
    {
        base.Start();
        speed = -speed;
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.CompareTag("Dragon"))
        {
            OnProjectilePlayerHit(coll);
        }
    }

    protected override void OnProjectilePlayerHit(Collider2D coll)
    {
        Damage dmg = new Damage()
        {
            damageAmmount = damage,
            knockBack = 0,
            origin = transform.position
        };
        coll.SendMessage("RecieveDamage", dmg);
        Destroy(gameObject);
    }
}