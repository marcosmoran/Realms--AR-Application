using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugMode : MonoBehaviour
{
    // Start is called before the first frame update
    public static DebugMode debug;
    public bool editorDebug;
    public bool appDebug;
    public TMPro.TMP_Text portalLocText;
    public StencilController stencilController;
    public GameObject ARCam;
    public GameObject DebugCam;
    public GameObject debugCanvas;
    void Start()
    {
        debug = this;
        if (Application.isEditor)
        {

            ARCam.SetActive(false);
            DebugCam.SetActive(true);
            editorDebug = true;

        }
        else
        {

            ARCam.SetActive(true);
            DebugCam.SetActive(false);
            editorDebug = false;
        }

        debugCanvas.SetActive(appDebug);

    }

    // Update is called once per frame
    void Update()
    {
        //        portalLocText.text = stencilController.isInsidePortal ? "Inside" : "Outside";
    }
}
