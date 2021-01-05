using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventParam
{
    public string eventString { get; set; }
    public GameObject gameObject { get; set; }

    public EventParam(string string_data, GameObject gameObject_data)
    {
        eventString = string_data;
        gameObject = gameObject_data;
    }

    public EventParam()
    {
        eventString = "";
        gameObject = null;
    }

    public EventParam(string string_data)
    {
        eventString = string_data;
        gameObject = null;
    }
    public EventParam(GameObject gameObject_data)
    {
        eventString = "";
        gameObject = gameObject_data;
    }
}
