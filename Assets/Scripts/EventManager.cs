using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public static EventManager singletonInstance;
    void Awake()
    {
        if (singletonInstance == null)
        {
            singletonInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public event Action<int, bool> SwitchTriggerEnter;

    public void OnSwitchTriggerEvent(int instanceId, bool switchState)
    {
        SwitchTriggerEnter?.Invoke(instanceId, switchState);
    }
}

