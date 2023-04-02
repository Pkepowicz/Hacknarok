using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Griffon : TestEnemy
{
    public GameObject prefab;
    public float damage;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(ShootCoroutine());
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.CompareTag("Dragon"))
        {
            Damage dmg = new Damage()
            {
                damageAmmount = damage,
                knockBack = 0,
                origin = transform.position
            };
            coll.SendMessage("RecieveDamage", dmg);
            Death();
        }
    }
    
    private IEnumerator ShootCoroutine()
    {
        // Wait for a random amount of time
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 6f));

            Shoot();

            //StartCoroutine(ShootCoroutine());
        }
    }

    private void Shoot()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    protected override void Death()
    {
        EnemyManager.instance.enemiesRemaining -= 1;
        Destroy(gameObject);
    }
}
