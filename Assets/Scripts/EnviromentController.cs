using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using DentedPixel;
using UnityEngine.Video;
public class EnviromentController : MonoBehaviour
{
    // This Scripts sets up the generated world inside portal, every time the player starts the experience it will select 3 items from different categories.
    // Enviroments are the skyboxes for the world inside portal
    // Artefacts are prefabs that will serve as content inside the portal
    // Events are scripted actions that can happen within the enviroment

    [SerializeField]
    List<GameObject> artefacts;
    GameObject currentArtefact;

    [SerializeField]
    VideoPlayer skybox;
    [SerializeField]
    List<VideoClip> enviromentsVideos;
    VideoClip currentEnviroment;
    [SerializeField]
    Volume postProcess;
    //List<Event> events;
    void Start()
    {
        Debug.Log("Enviroment Controller Initialized");

        //Testing
        skybox.gameObject.SetActive(false);
        Events.events.onPortalSpawned += PortalSpawned;
        Events.events.onEnteredPortal += PortalEntered;
        Events.events.onExitedPortal += PortalExited;


    }
    #region Enviroment and Artefact Testing
    public void ChooseArtefact(int artefactID)
    {
        currentArtefact = artefacts[artefactID];

        foreach (GameObject artefact in artefacts)
        {

            artefact.SetActive(false);

        }
    }
    public void ChooseVideoEnviroment(int videoID)
    {
        currentEnviroment = enviromentsVideos[videoID];
        skybox.clip = currentEnviroment;
        skybox.Play();

    }
    #endregion

    void PortalSpawned()
    {
        skybox.gameObject.SetActive(true);
    }
    void PortalEntered()
    {
        Shader.SetGlobalInt("_InsidePortalStencilComp", 6);
        currentArtefact.SetActive(true);
        // var postprocessWeight = 1;
        // LeanTween.value(postprocessWeight, 1, 0.5f).setOnUpdate((float val) =>
        // {
        //     postProcess.weight = val;
        // });
    }

    void PortalExited()
    {
        Shader.SetGlobalInt("_InsidePortalStencilComp", 3);

        // postProcess.weight = 0;
    }
}