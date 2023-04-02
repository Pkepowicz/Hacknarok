using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Fighter
{
    public float moveSpeedX = 2.0f;
    public float horizontalSpeed;
    public Vector3 stationaryPosition;
    public float maxHorizontalMove = 3f;
    public GameObject prefab;
    public Transform[] spawnPoints;
    
    protected override void Start()
    {
        base.Start();
        stationaryPosition = transform.position;
        horizontalSpeed = moveSpeedX;
        StartCoroutine(Shoot());
    }

    protected override void Update()
    {
        base.Update();
        if (transform.position.x < stationaryPosition.x - maxHorizontalMove)
        {
            moveSpeedX = horizontalSpeed;
        }
        if (transform.position.x > stationaryPosition.x + maxHorizontalMove)
        {
            moveSpeedX = -horizontalSpeed;
        }
        transform.Translate(moveSpeedX * Time.deltaTime, 0, 0);
    }

    protected IEnumerator Shoot()
    {
        while(true)
        {
            Instantiate(prefab, spawnPoints[Random.Range(0, 3)].position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}