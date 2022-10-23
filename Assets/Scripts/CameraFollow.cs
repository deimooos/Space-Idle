//using StandardAssets;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow scr;
    // camera will follow this object
    public Transform Target;
    //camera transform
    public Transform camTransform;
    // offset between camera and target
    Vector3 v3Pos;
    public Vector3 Offset;
    public Quaternion offsetRotation;
    Quaternion startRot;   
    float zoomOut;
    // change this value to get desired smoothness
    public float SmoothTime;
    public bool targetC = true;
    bool isOnce = true;

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        scr = this;
    }
    private void Start()
    {
        camTransform = transform;
        //Target = GameObject.Find("Player").transform;
        //Target = GameObject.Find("Rocket").transform;
        startRot = camTransform.rotation;
        //Offset *= SA.CameraScale();
        
        //camTransform.position = Target.position + Offset;
    }

    private void LateUpdate()
    {
        if (targetC)
        {

            Vector3 targetPosition = Target.position + Offset;
            //Vector3 targetPosition = Target.position + Offset.y * transform.up + (Offset.z) * transform.forward + Offset.x * transform.right;
            camTransform.position = Vector3.Lerp(camTransform.position, targetPosition, 1);

        }

    }
    



}
