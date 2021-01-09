using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARSubsystems;

public class ARController : MonoBehaviour
{
    [SerializeField]
    PortalController portalController;
    bool planeFound = false;

    [SerializeField]
    private ARPlaneManager planeManager;


    void Start()
    {
        Screen.fullScreen = false;
        Debug.Log("AR Controller Initialized");
        planeManager.planesChanged += FindPlane;

    }

    // Update is called once per frame
    void Update()
    {

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

