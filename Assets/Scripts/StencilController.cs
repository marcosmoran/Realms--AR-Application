using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
public class StencilController : MonoBehaviour
{

    [SerializeField]
    Portal portal;
    Material[] materials;
    [SerializeField]
    MeshRenderer meshRenderer;
    [HideInInspector]
    public bool isInsidePortal = false;
    void Start()
    {
        // ChangeMatStencil(3);
        // meshRenderer = GetComponent<MeshRenderer>();
    }


    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        var cameraPos = col.transform.position;
        portal.CheckEnterCollision(transform.root.position);
        // Debug.Log("Collision");
        // Vector3 playerPos = Camera.main.transform.position + Camera.main.transform.forward * (Camera.main.nearClipPlane * 4);

        // if (transform.root.position.z > col.transform.position.z)
        // {
        //     if (!isInsidePortal)
        //     {
        //         ChangeMatStencil(6);
        //         isInsidePortal = true;
        //     }
        // }
        // else if (isInsidePortal)
        // {
        //     ChangeMatStencil(3);
        //     isInsidePortal = false;
        //     Debug.Log("exited portal");
        // }
        // meshRenderer.enabled = false;
        // Debug.Log("Mesh Off");
    }

    void OnTriggerExit(Collider col)
    {
        portal.CheckExitCollision();
        // meshRenderer.enabled = true;
        // Debug.Log("Mesh On");
    }

    void ChangeMatStencil(int stencilNum)
    {
        // meshRenderer.enabled = false;
        // foreach (Material mat in materials)
        // {
        //     mat.SetInt("_Stencil", stencilNum);
        // }
        // meshRenderer.enabled = true;
    }

}

