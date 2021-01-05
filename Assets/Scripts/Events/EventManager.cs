using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EventManager : MonoBehaviour
{

    static Dictionary<EventName, Action<EventParam>> eventDictionary;

    public static void Initialize()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<EventName, Action<EventParam>>();
        }
    }

    public static void StartListening(EventName eventName, Action<EventParam> listener)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            /// Add more events
			eventDictionary[eventName] += listener;
        }
        else
        {
			/// Add event to dictionary for the first time
            eventDictionary.Add(eventName, listener);
        }
    }

    public static void StopListening(EventName eventName, Action<EventParam> listener)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            /// remove events
			eventDictionary[eventName] -= listener;
        }
    }

    public static void TriggerEvent(EventName eventName, EventParam eventParam)
    {
        Action<EventParam> thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(eventParam);
        }
    }
}


// public class EventManager : MonoBehaviour
// {

//     private Dictionary<EventName, Action<EventParam>> eventDictionary;

//     private static EventManager eventManager;

// 	/// create instance if one doesn't exist
//     public static EventManager instance
//     {
//         get
//         {
//             if (!eventManager)
//             {
//                 eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

//                 if (!eventManager)
//                 {
//                     Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
//                 }
//                 else
//                 {
//                     eventManager.Initialize();
//                 }
//             }

//             return eventManager;
//         }
//     }

//     public static void Initialize()
//     {
//         if (eventDictionary == null)
//         {
//             eventDictionary = new Dictionary<EventName, Action<EventParam>>();
//         }
//     }

//     public static void StartListening(EventName eventName, Action<EventParam> listener)
//     {
//         if (instance.eventDictionary.ContainsKey(eventName))
//         {
//             /// Add more events
// 			instance.eventDictionary[eventName] += listener;
//         }
//         else
//         {
// 			/// Add event to dictionary for the first time
//             instance.eventDictionary.Add(eventName, listener);
//         }
//     }

//     public static void StopListening(EventName eventName, Action<EventParam> listener)
//     {
//         if (instance.eventDictionary.ContainsKey(eventName))
//         {
//             /// remove events
// 			instance.eventDictionary[eventName] -= listener;
//         }
//     }

//     public static void TriggerEvent(EventName eventName, EventParam eventParam)
//     {
//         Action<EventParam> thisEvent = null;
//         if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
//         {
//             thisEvent.Invoke(eventParam);
//         }
//     }
// }