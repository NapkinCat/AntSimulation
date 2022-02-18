using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //Instantiate camera gameobject; in UnityUI, this is assigned as the primary camera object
    public GameObject cameraObject;

    //Instantiate camera speed variable; public so UnityUI can manipulate with ease
    public float cameraSpeed;
    public float cameraZoomSpeed;

    //Instantiate camera zoom limits; public so UnityUI can manipulate these
    public float maxZoom;
    public float minZoom;

    //Instantiate private variable to handle camera movement vector
    private Vector3 cameraTranslationVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get our translation vector from user input, to be used in the FixedUpdate Method
        cameraTranslationVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetAxis("Mouse ScrollWheel"));
        Debug.Log(Input.GetAxis("Mouse ScrollWheel"));

        if (cameraObject.transform.position.z > maxZoom || cameraObject.transform.position.z < minZoom)
        {
            cameraTranslationVector.z *= -1;
        }
    }

    
    void FixedUpdate()
    {
        //Apply the translation vector from user input to modify position of the camera.
        cameraObject.transform.position += cameraTranslationVector * cameraSpeed;

        //cameraObject.transform.position.Set(cameraObject.transform.position.x + (cameraTranslationVector.x * cameraSpeed), 
        //    cameraObject.transform.position.y + (cameraTranslationVector.y * cameraSpeed),
        //    cameraObject.transform.position.z);
    }

}
