using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    // Start is called before the first frame update
    public float gravity = -10;
    public Quaternion targetRotation;
    GameObject light;
    public Vector3 bodyUp;
    public Vector3 Offset = new Vector3(45,0,0);
    
    private void Start()
    {
        
        light = GameObject.Find("Directional Light");
    }
    public void Attract(Transform body)
    {
       
        Vector3 gravityUp = (body.position - transform.position).normalized;
        bodyUp = body.up;

        body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        targetRotation = Quaternion.FromToRotation(bodyUp , gravityUp) * body.rotation;
        //targetRotation = new Quaternion(targetRotation.x, 0, targetRotation.y, 0);
        body.rotation = Quaternion.Slerp(body.rotation,targetRotation,50*Time.deltaTime);
       
        Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, targetRotation * Quaternion.Euler(Offset.x,Offset.y,Offset.z)/*Quaternion.Euler(45,0,0)*/, 50 * Time.deltaTime);
        RenderSettings.skybox.SetVector("_Up", bodyUp);
       
    }


    
}
