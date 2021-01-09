using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using DentedPixel;
public class EnviromentController : MonoBehaviour
{
    // This Scripts sets up the generated world inside portal, every time the player starts the experience it will select 3 items from different categories.
    // Enviroments are the skyboxes for the world inside portal
    // Artefacts are prefabs that will serve as content inside the portal
    // Events are scripted actions that can happen within the enviroment

    [SerializeField]
    List<GameObject> artefacts;
    List<Material> enviroments;
    [SerializeField]
    public GameObject currentArtefact;
    public GameObject currentEnviroment;
    [SerializeField]
    Volume postProcess;
    //List<Event> events;
    void Start()
    {
        Debug.Log("Enviroment Controller Initialized");
        PortalExit();
        currentEnviroment.SetActive(false);
        Events.events.onEnteredPortal += PortalEnter;
        Events.events.onExitedPortal += PortalExit;

    }

    void PortalEnter()
    {
        Shader.SetGlobalInt("_InsidePortalStencilComp", 6);
        currentArtefact.SetActive(true);
        var postprocessWeight = 0;
        LeanTween.value(postprocessWeight, 1, 0.5f).setOnUpdate((float val) =>
        {
            postProcess.weight = val;
        });
    }

    void PortalExit()
    {
        Shader.SetGlobalInt("_InsidePortalStencilComp", 3);
        currentArtefact.SetActive(false);
        postProcess.weight = 0;
    }
}