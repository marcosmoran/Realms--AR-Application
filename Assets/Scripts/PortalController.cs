using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    #region Class References
   
    [SerializeField]
    EnviromentController enviromentController;


    #endregion

    #region Object References
    [SerializeField]
    GameObject portal;
    GameObject portalWindow;
    MeshRenderer portalDistorion;
    GameObject portalStencil;
    MeshRenderer doorFrame;
    MeshRenderer door;
    Animator portalDoorAnim;
    #endregion

    bool isInsidePortal = false;
    void Start()
    {
        Debug.Log("Portal Controller Initialized");

        GetPortalRefs();
        SetInitialValues();
        Events.events.ExitedPortal();
        
    }

    void GetPortalRefs()
    {
        door = GameObject.Find(portal.name + "/Portal Door/Door").GetComponent<MeshRenderer>();
        portalDoorAnim = door.GetComponent<Animator>();
        doorFrame = GameObject.Find(portal.name + "/Portal Door/Door Frame").GetComponent<MeshRenderer>();
        portalWindow = GameObject.Find(portal.name + "/Portal Door/Window");
        portalStencil = GameObject.Find(portal.name + "/Portal Door/Stencil");
        portalDistorion = GameObject.Find(portal.name + "/Portal Door/Window/Distortion").GetComponent<MeshRenderer>();
    }
    void SetInitialValues()
    {
        door.material.SetFloat("_DissolveAmount", 1);
        doorFrame.material.SetFloat("_DissolveAmount", 1);
        portalDistorion.material.SetFloat("Alpha", 0);

        portalWindow.SetActive(false);
        portalStencil.SetActive(false);
    }
    void Update()
    {
        if (!isInsidePortal)
        {
            PortalWindowOpacity();
        };
    }

    public void SpawnPortal()
    {

        Debug.Log("Spawning Portal");
        portal.transform.position = Camera.main.transform.position + new Vector3(-0.5f, -2, 3);
        var dissolvedAmount = 1;

        // animate the portal shader and door opening
        LeanTween.value(dissolvedAmount, 0f, 1f).setEase(LeanTweenType.easeInQuad)
        .setOnUpdate((float val) =>
        {
            door.material.SetFloat("_DissolveAmount", val);
            doorFrame.material.SetFloat("_DissolveAmount", val);
        })
        .setOnComplete(() =>
        {
            portalWindow.SetActive(true);
            portalStencil.SetActive(true);

            Events.events.PortalSpawned();
            portalDoorAnim.Play("OpenDoor");
        }
        );

    }
    void PortalWindowOpacity()
    {
        var distance = Vector3.Distance(Camera.main.transform.position, portalWindow.transform.position);

        if (distance < 3)
        {
            if (distance < 1)
            {
                float t2 = Mathf.InverseLerp(1, 0.5f, distance);
                float distortionAlpha = Mathf.Lerp(0f, 0.5f, t2);
                portalWindow.GetComponent<MeshRenderer>().material.SetFloat("_Alpha", distortionAlpha);
            }
            // map camera distance to control alpha value in portal effect shader
            float t = Mathf.InverseLerp(3, 0.5f, distance);
            float portalAlpha = Mathf.Lerp(0.7f, 0.02f, t);
            portalWindow.GetComponent<MeshRenderer>().material.SetFloat("_Alpha", portalAlpha);
        }
    }

    #region Stencil Logic

    public void CheckEnterCollision(Vector3 rootPos)
    {
        //Logic for OnTriggerEnter in the portal stencil collider
        Debug.Log("Collision");

        Vector3 playerPos = Camera.main.transform.position;

        Debug.Log("RootPos " + rootPos.z + " Player Pos " + playerPos.z);
        if (rootPos.z > playerPos.z)
        {
            if (!isInsidePortal)
            {
                Events.events.EnteredPortal();

                isInsidePortal = true;
            }
        }
        else if (isInsidePortal)
        {
            Events.events.ExitedPortal();

            isInsidePortal = false;

        }
        portalStencil.GetComponent<MeshRenderer>().enabled = false;
        Debug.Log("Mesh Off");
    }

    public void CheckExitCollision()
    {
        //Logic for the OnTriggerExit in the portal stencil collider
        portalStencil.GetComponent<MeshRenderer>().enabled = true;
    }

    #endregion

}
