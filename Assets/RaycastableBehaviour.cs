using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastableBehaviour : MonoBehaviour
{
    public UnityEvent magicalEvents;

    public void TriggerBehaviour()
    {
        magicalEvents.Invoke();
    }
}
