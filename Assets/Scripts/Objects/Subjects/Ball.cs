using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Subject
{
    float ballRadius;
    void Awake()
    {
        ballRadius = gameObject.GetComponent<SphereCollider>().radius;
    }

    protected override void CheckBounds()
    {
        // Debug.Log("Distance on trigger is " + (GroundDistance(gameObject.transform.position) - ballRadius).ToString());

        if (GroundDistance(gameObject.transform.position) - ballRadius < targetRadius)
        {
            TargetReached(gameObject.name);
        }
    }
}
