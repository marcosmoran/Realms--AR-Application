﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARSubsystems;

public class ARController : MonoBehaviour
{
    [SerializeField]
    Portal portalController;
    bool planeFound = false;

    [SerializeField]
    private ARPlaneManager planeManager;


    void Start()
    {
        Screen.fullScreen = false;
        Debug.Log("AR Controller Initialized");
        if (!DebugMode.debug.appDebug) planeManager.planesChanged += FindPlane;

    }
    
    public void ActivatePlaneDetect()
    {
        if (DebugMode.debug.editorDebug)
        {
            portalController.SpawnPortal();
        }
        else
        {
            planeManager.planesChanged += FindPlane;
        }
        Events.events.ExitedPortal();
    }

    void FindPlane(ARPlanesChangedEventArgs args)
    {
        if (planeFound) return;
        Debug.Log("Looking for Plane");
        if (args.added != null)
        {
            //once a plane has been found a portal can be created
            portalController.SpawnPortal();
            planeFound = true;
            Debug.Log("Plane Found");
        }

    }
}

