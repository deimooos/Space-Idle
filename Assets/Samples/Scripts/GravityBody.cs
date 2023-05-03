using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GravityAttractor attractor;
    private Transform myTransform;
    private Rigidbody rb ;
    GlobalSettings globalSettings;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
        myTransform = transform;
        globalSettings = GameObject.Find("GlobalSettings").GetComponent<GlobalSettings>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (globalSettings.gameFinished)
        {
            this.enabled = false;
        }
        attractor.Attract(myTransform);
    }
}
