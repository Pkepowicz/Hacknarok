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
    private bool isOnPosition = false;
    private float tolerance = 0.1f;

    protected override void Start()
    {
        base.Start();
        stationaryPosition = new Vector3(0,4,0);
        horizontalSpeed = moveSpeedX;
        StartCoroutine(Shoot());
    }

    protected override void Update()
    {
        base.Update();
        if (!isOnPosition)
        {
            Vector3 direction = stationaryPosition - transform.position;
            transform.position += direction.normalized * 0.2f * Time.deltaTime;
            if (direction.magnitude <= tolerance)
            {
                isOnPosition = true;
            }
        }

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