using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    //Assign a GameObject in the Inspector to rotate around
    [Header("Rotation Properties")]
    public GameObject target;
    public int rotateSpeed = 10;

    // Call once a frame
    void Update()
    {
        // Spin the object around the target at specified degrees/second.
        transform.RotateAround(target.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
