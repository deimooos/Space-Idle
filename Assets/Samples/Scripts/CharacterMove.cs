using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public GameObject capacityText;
    public GameObject carryText;
    public GameObject Helmet;

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
        capacityText.SetActive(transform.GetChild(1).GetComponent<Renderer>().enabled);
        carryText.SetActive(transform.GetChild(1).GetComponent<Renderer>().enabled);
        Helmet.SetActive(transform.GetChild(1).GetComponent<Renderer>().enabled);

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

                    Quaternion targetRotation = Quaternion.LookRotation(moveDir);
                    transform.rotation = Quaternion.Slerp(curRotation, targetRotation, 10f * Time.deltaTime);
                    //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), 10 * Time.deltaTime);                  
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
        if(GlobalSettings.scr.carryAmount==carrier.transform.childCount)
        {
            carryText.GetComponent<Text>().text = "   MAX";
            capacityText.GetComponent<Text>().text = "";
            carryText.GetComponent<Text>().color = Color.red;
        }
        else
        {
            carryText.GetComponent<Text>().color = Color.white;
            capacityText.GetComponent<Text>().text = GlobalSettings.scr.carryAmount.ToString();

            carryText.GetComponent<Text>().text = carrier.transform.childCount.ToString() + "/";
        }

        

        Vector3 temp;
        temp = carryText.transform.parent.transform.localEulerAngles;
        carryText.transform.parent.transform.LookAt(Camera.main.transform);
        temp.y = carryText.transform.parent.transform.localEulerAngles.y+180;
        carryText.transform.parent.transform.localEulerAngles = temp;
        
        /*carryText.transform.LookAt(Camera.main.transform);
        capacityText.transform.LookAt(Camera.main.transform);*/

        


    }



}