using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMode : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isOn;
    public TMPro.TMP_Text portalLocText;
    public StencilController stencilController;
    public GameObject ARCam;
    public GameObject DebugCam;
    void Start()
    {
        if (Application.isEditor)
        {

            ARCam.SetActive(false);
            DebugCam.SetActive(true);
            isOn = true;

        }
        else
        {

            ARCam.SetActive(true);
            DebugCam.SetActive(false);
            isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        portalLocText.text = stencilController.isInsidePortal ? "Inside" : "Outside";
    }
}
