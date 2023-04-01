using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Fighter
{
    public float moveSpeedX = 2.0f;
    public float moveSpeedY = 2.0f;
    public Vector3 stationaryPosition;
    public float horizontalSpeed = 10f;
    public float verticalSpeed = 10f;
    public float maxHorizontalMove = 30f;
    public float maxVerticalMove = 2.0f;
    private bool isOnPosition;
    public float tolerance = 0.1f;

    protected override void Start()
    {
        base.Start();
    }
    
    protected override void Update()
    {
        base.Update();
        // code that moves object in x axis and changes direction when moves more than maxMove from waypoint location
        if(!isOnPosition)
        {
            Vector3 direction = stationaryPosition - transform.position;
            transform.position += direction.normalized * horizontalSpeed * Time.deltaTime;
            if(direction.magnitude <= tolerance)
            {
                isOnPosition = true;
            }
            return;
        }
        if (transform.position.x < stationaryPosition.x - maxHorizontalMove)
        {
            moveSpeedX = horizontalSpeed;
        }
        if (transform.position.x > stationaryPosition.x + maxHorizontalMove)
        {
            moveSpeedX = -horizontalSpeed;
        }
        if (transform.position.y < stationaryPosition.y - maxVerticalMove)
        {
            moveSpeedY = verticalSpeed;
        }
        if (transform.position.y > stationaryPosition.y + maxVerticalMove)
        {
            moveSpeedY = -verticalSpeed;
        }
        transform.Translate(moveSpeedX * Time.deltaTime, moveSpeedY * Time.deltaTime, 0);
    }
}
        