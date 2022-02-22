using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBehavior : MonoBehaviour
{

    #region Public Variables
    public float rotationSpeed;
    public float moveSpeed;
    #endregion

    #region Private Variables
    public Vector3 lookVector;
    public float rotationInput;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        lookVector = new Vector3(0, 1, 0);
        lookVector = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward) * lookVector;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate transform(sprite) to look in direction of our lookVector;
        Vector3 relativeTarget = (lookVector).normalized;
        Quaternion toQuaternion = Quaternion.FromToRotation(Vector3.up, relativeTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, toQuaternion, rotationSpeed);

        //Rotate lookvector, randomly by specified degree over time;
        lookVector = Quaternion.AngleAxis(rotationInput * rotationSpeed * Time.deltaTime, Vector3.forward) * lookVector;

        //Move forward at speed
        transform.position += lookVector * moveSpeed * Time.deltaTime;
    }

    public void SetRotationInput(float newInput)
    {
        rotationInput = newInput * rotationSpeed * 100;
    }
}
