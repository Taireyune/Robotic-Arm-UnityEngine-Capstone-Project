using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    protected Vector3 targetPosition;
    protected float targetRadius;


    void FixedUpdate()
    {
        /// When object fall off of the platform, game ends
        if (gameObject.transform.position.y < -3.0f)
        {
            EventManager.TriggerEvent(EventName.GameOverEvent, new EventParam());
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Target")
        {
            // Debug.Log("in region, check bounds");
            CheckBounds();
        }
    }
    /// When subject approach target, check bounds (implemented in child classes)
    protected virtual void CheckBounds()
    {
        /// implemented in child
    }

    /// set target region after instantiation
    public void SetTargetRegion(Vector3 position, float radius)
    {
        targetPosition = position;
        targetRadius = radius;
    }
    
    /// get distance without y component
    protected float GroundDistance(Vector3 position)
    {
        Vector3 distanceIntermediate = position - targetPosition;
        distanceIntermediate.y = 0;
        return distanceIntermediate.magnitude;
    }

    /// when target is reached, send subject name with event signal
    protected virtual void TargetReached(string subject_name)
    {
        EventManager.TriggerEvent(EventName.TargetReached, new EventParam(subject_name));
    }
}
