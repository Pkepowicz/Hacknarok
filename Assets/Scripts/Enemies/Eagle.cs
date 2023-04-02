using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Eagle : TestEnemy
{
    public float damage = 1.0f;
    public float speed = 5.0f;
    public bool isCharging = false;
    public Transform target;

    protected override void Start()
    {
        base.Start();
        target = GameObject.FindGameObjectWithTag("Finish").transform;
        StartCoroutine(StartCharge());
    }

    protected override void Update()
    {
        if (isCharging)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
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

    private IEnumerator StartCharge()
    {
        // Wait for a random amount of time
        yield return new WaitForSeconds(Random.Range(5f, 15f));
        
        // Change the boolean value
        isCharging = true;
        horizontalSpeed = 0;
        verticalSpeed = 0;
        moveSpeedX = 0;
        moveSpeedY = 0;
}
    
    protected override void Death()
    {
        EnemyManager.instance.enemiesRemaining -= 1;
        Destroy(this.gameObject);
    }
}

