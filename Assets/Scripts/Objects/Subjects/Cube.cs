using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Subject
{
    /// vertices of cube corners based on its box collider orientation
    Vector3[] collider_vertices = new Vector3[8];
    BoxCollider box_collider;

    void Awake()
    {
        box_collider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    protected override void CheckBounds()
    {
        bool in_bounds = true;
        UpdateColliderVertices();
        foreach (Vector3 vertex in collider_vertices)
        {
            // Debug.Log(GroundDistance(vertex).ToString());
            // Debug.Log(targetRadius.ToString());
            if (GroundDistance(vertex) > targetRadius)
            {
                in_bounds = false;
                break;
            }
        }

        if (in_bounds)
        {
            TargetReached(gameObject.name);
        }
    }

    /// update the current box collider vertices
    void UpdateColliderVertices()
    {
        collider_vertices[0] = gameObject.transform.TransformPoint(box_collider.center + new Vector3(-box_collider.size.x, -box_collider.size.y, -box_collider.size.z) * 0.5f);
        collider_vertices[1] = gameObject.transform.TransformPoint(box_collider.center + new Vector3(box_collider.size.x, -box_collider.size.y, -box_collider.size.z) * 0.5f);
        collider_vertices[2] = gameObject.transform.TransformPoint(box_collider.center + new Vector3(box_collider.size.x, -box_collider.size.y, box_collider.size.z) * 0.5f);
        collider_vertices[3] = gameObject.transform.TransformPoint(box_collider.center + new Vector3(-box_collider.size.x, -box_collider.size.y, box_collider.size.z) * 0.5f);
        collider_vertices[4] = gameObject.transform.TransformPoint(box_collider.center + new Vector3(-box_collider.size.x, box_collider.size.y, -box_collider.size.z) * 0.5f);
        collider_vertices[5] = gameObject.transform.TransformPoint(box_collider.center + new Vector3(box_collider.size.x, box_collider.size.y, -box_collider.size.z) * 0.5f);
        collider_vertices[6] = gameObject.transform.TransformPoint(box_collider.center + new Vector3(box_collider.size.x, box_collider.size.y, box_collider.size.z) * 0.5f);
        collider_vertices[7] = gameObject.transform.TransformPoint(box_collider.center + new Vector3(-box_collider.size.x, box_collider.size.y, box_collider.size.z) * 0.5f);
        // Debug.Log(collider_vertices[0].ToString());
    }
}
