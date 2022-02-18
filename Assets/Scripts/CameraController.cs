using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Public Variables
    //Instantiate camera gameobject; in UnityUI, this is assigned as the primary camera object
    public GameObject cameraObject;

    //Instantiate camera speed variable; public so UnityUI can manipulate with ease
    public float cameraSpeed;
    public float cameraZoomSpeed;
    public float zoomSpeedDecay;

    //Instantiate camera zoom limits; public so UnityUI can manipulate these
    public float maxZoom;
    public float minZoom;
    #endregion

    #region Private Variables
    //Instantiate private variable to handle camera movement vector
    private Vector3 cameraTranslationVector;
    private float zoomVelocity;

    #endregion

    // Update is called once per frame; get inputs and modify vectors once per frame
    void Update()
    {
        //Acquire scroll wheel input;  If there is input, set zoomVelocity.  If there is no input, apply decay to the zoom velocity to smooth camera zooming.
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheelInput != 0)
        {
            zoomVelocity = scrollWheelInput;
        }
        else
        {
            zoomVelocity *= zoomSpeedDecay;
        }

        //Get our translation vector from user input, to be used in the FixedUpdate Method
        cameraTranslationVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), zoomVelocity);
    }

    //Apply movement vectors in a capacity untied to the framerate for smoothness and consistency
    void FixedUpdate()
    {
        //Apply the translation vector from user input to modify position of the camera.
        cameraObject.transform.position += cameraTranslationVector * cameraSpeed;

        //Keep camera within zoom bounds
        if (cameraObject.transform.position.z > maxZoom)
        {
            cameraObject.transform.position = new Vector3(cameraObject.transform.position.x, cameraObject.transform.position.y, maxZoom);
        }
        else if (cameraObject.transform.position.z < minZoom)
        {
            cameraObject.transform.position = new Vector3(cameraObject.transform.position.x, cameraObject.transform.position.y, minZoom);
        }
    }
}
