using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Events : MonoBehaviour
{
    public static Events events;
    void Awake()
    {
        events = this;
    }

    public event Action onEnteredPortal;
    public void EnteredPortal()
    {
        if (onEnteredPortal != null)
        {
            Debug.Log("Entered Portal");
            onEnteredPortal();
        }
    }
    public event Action onExitedPortal;
    public void ExitedPortal()
    {
        if (onExitedPortal != null)
        {
            Debug.Log("Exited Portal");
            onExitedPortal();
        }
    }

}
