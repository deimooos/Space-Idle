using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMove : MonoBehaviour
{
    public static CharacterMove scr;
    Joystick joystick;
    public Rigidbody rb;
    public float moveSpeed = 10f;
    public Animator anim;
    public  bool isRunning;
    public Vector3 moveDir;
    public GameObject axe;
    public GameObject pickaxe;
    public GameObject carrier;

    
     

    void Awake()
    {
        scr = this;
        joystick = FindObjectOfType<Joystick>();
        rb = gameObject.GetComponent<Rigidbody>();
        anim = transform.GetChild(0).gameObject.GetComponent<Animator>();
        this.enabled = false;
       

    }

    // Update is called once per frame
    
    void FixedUpdate()
    { 
            moveSpeed = GlobalSettings.scr.moveSpeed;
            /*if(gameObject.GetComponent<MeshRenderer>())
            paintSphere.Color = gameObject.GetComponent<MeshRenderer>().sharedMaterial.color;*/


            rb.velocity = new Vector3(joystick.Horizontal * moveSpeed,
                      rb.velocity.y,
                      joystick.Vertical * moveSpeed);

        if (rb.velocity.y > 0)
        {
            rb.velocity = new Vector3(joystick.Horizontal * moveSpeed,
                     0,
                      joystick.Vertical * moveSpeed);
        }

            if (Mathf.Abs(joystick.Horizontal) >= 0.1f || Mathf.Abs(joystick.Vertical) >= 0.1f)
            {
                anim.SetBool("isRunning", true);
                moveDir = new Vector3(joystick.Horizontal, 0, joystick.Vertical);

                Quaternion curRotation = transform.rotation;
                Vector3 velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                if (moveDir != Vector3.zero)
                {

                    /*Quaternion targetRotation = Quaternion.LookRotation(moveDir);
                    transform.rotation = Quaternion.Slerp(curRotation, targetRotation, 10f * Time.deltaTime);*/
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), 10 * Time.deltaTime);                  
                    isRunning = true;
                }
                //rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
            }
            else
            {
                rb.velocity = new Vector3(0,
                      rb.velocity.y,
                      0);
                isRunning = false;
                anim.SetBool("isRunning", false);

            }
        if (GlobalSettings.scr.gameFinished)
        {

            rb.velocity = Vector3.zero;
        }



    }
    
}