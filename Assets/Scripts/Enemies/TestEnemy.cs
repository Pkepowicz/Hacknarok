using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Fighter
{
    public float moveSpeed = 2.0f;
    private Vector2 waypoint;
    public float speed = 10f;
    public float maxMove = 30f;

    protected override void Start()
    {
        base.Start();
        waypoint = transform.position;
    }
    
    protected override void Update()
    {
        base.Update();
        // code that moves object in x axis and changes direction when moves more than maxMove from waypoint location
        if (transform.position.x < waypoint.x - maxMove)
        {
            moveSpeed = speed;
        }
        if (transform.position.x > waypoint.x + maxMove)
        {
            moveSpeed = -speed;
        }
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }
}
        