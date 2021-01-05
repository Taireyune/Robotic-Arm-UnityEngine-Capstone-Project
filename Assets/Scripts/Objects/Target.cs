using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnTriggerEnter(Collider other) 
    // {
    //     if (other.tag == "Subject")
    //     {  
    //         Debug.Log("Target OnTriggerEnter");
    //         /// check if subject is within the target area
    //         EventManager.TriggerEvent(EventName.CheckTargetReached, new EventParam());
    //     }
    //     // if (other.tag == "Robotic_arm")
    //     // {
    //     //     Debug.Log("arm touch");
    //     // }
    //     // Debug.Log("touched something");
    // }

    // void OnTriggerStay(Collider other)
    // {
    //     if (other.tag == "Subject")
    //     {  
    //         // Debug.Log("Target OnTriggerStay");
    //         /// check if subject is within the target area
    //         EventManager.TriggerEvent(EventName.CheckTargetReached, new EventParam());
    //     }       
    // }
}
