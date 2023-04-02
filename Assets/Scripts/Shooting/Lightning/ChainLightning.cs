using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ChainLightning : Collidable
{
    
    public float damage;
    public GameObject chainLightningEffect;
    public GameObject beenStruck;
    private int singleSpawns;
    public int amountToChain;
    private GameObject startObject;
    public GameObject endObject;
    private Animator ani;
    public ParticleSystem parti;

    protected override void Start()
    {
        base.Start();
        singleSpawns = 1;
        if(amountToChain == 0) Destroy(gameObject);
        Destroy(gameObject, .4f);
        ani = GetComponent<Animator>();

        chainLightningEffect = gameObject;
        
        startObject = gameObject;

        parti = GetComponent<ParticleSystem>();
    }
    
 
    
    protected override void OnCollide(Collider2D coll)
    {
        //Debug.Log("OnCollide was not implemented in " + this.name);
        
        // interact with enemy, and destroy itself
        if (coll.CompareTag("Enemy") && !coll.GetComponentInChildren<EnemyStruck>())
        {
            if (singleSpawns != 0)
            {
                Debug.Log("Collided with enemy");
                
                Instantiate(beenStruck, coll.gameObject.transform);
                GameObject instance = Instantiate(chainLightningEffect, coll.transform.position, Quaternion.identity, coll.transform);
                instance.GetComponent<ChainLightning>().ReduceChains();
                //gameObject.transform.parent = coll.transform;
                TurnOffColider();
                singleSpawns--;
                amountToChain -= 1;
                
                endObject = coll.gameObject;
                Debug.Log("End object found: " + endObject.name);
                ani.StopPlayback();

                parti.Play();
                var emitParams = new ParticleSystem.EmitParams();
                emitParams.position = startObject.transform.position;
                
                parti.Emit(emitParams, 1);
                
                emitParams.position = endObject.transform.position;
                
                parti.Emit(emitParams, 1);

                emitParams.position = (startObject.transform.position + endObject.transform.position)/2;
                
                parti.Emit(emitParams, 1);
                
                Destroy(gameObject, 1f);
                
                
                
            }
            
            
        }
    }

    public void ReduceChains()
    {
        amountToChain--;
        if (amountToChain <= 0)
        {
            Destroy(gameObject);
        }
    }

    /*public LayerMask enemyLayer;
    
    

    

    
    
    // Start is called before the first frame update
    

    protected void OnCollisionEnter(Collision collision)
    {

        /*if(enemyLayer == (enemyLayer | (1 << collision.gameObject.layer)) && !collision.gameObject.GetComponentInChildren<EnemyStruck>())
        {
            if (singleSpawns != 0)
            {

                Instantiate(chainLightningEffect, collision.gameObject.transform.position, Quaternion.identity);

                Instantiate(beenStruck, collision.gameObject.transform);

                Damage damage = new Damage()
                {
                    damageAmmount = this.damage,
                    knockBack = 0,
                    origin = transform.position
                };
                collision.gameObject.GetComponent<Fighter>().SendMessage("RecieveDamage", damage);
                //coll.SendMessage("RecieveDamage", damage);
                

                //

                singleSpawns--;
                
                
                
                
            }
        }*/
   // }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(enemyLayer == (enemyLayer | (1 << collision.gameObject.layer)) && !collision.GetComponentInChildren<EnemyStruck>())
        {
            if (singleSpawns != 0)
            {



                endObject = collision.gameObject;
                Debug.Log("End object found: " + endObject.name);

                amountToChain -= 1;
                Instantiate(chainLightningEffect, collision.gameObject.transform.position, Quaternion.identity);

                Instantiate(beenStruck, collision.gameObject.transform);

                Damage damage = new Damage()
                {
                    damageAmmount = this.damage,
                    knockBack = 0,
                    origin = transform.position
                };
                coll.SendMessage("RecieveDamage", damage);
                ani.StopPlayback();

                coll.enabled = false;

                singleSpawns--;
                
                parti.Play();
                
                var emitParams = new ParticleSystem.EmitParams();
                emitParams.position = startObject.transform.position;
                
                parti.Emit(emitParams, 1);
                
                emitParams.position = endObject.transform.position;
                
                parti.Emit(emitParams, 1);

                Destroy(gameObject, 1f);
            }
        }
    }*/

}
