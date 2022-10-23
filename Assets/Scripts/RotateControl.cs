using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateControl : MonoBehaviour
{
    Vector3 moveDir;
    GlobalSettings globalSettings;
    bool isOnce = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveDir = CharacterMove.scr.moveDir;
        if (moveDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 5f * Time.deltaTime);
            //transform.rotation = Quaternion.Slerp(transform.rotation,transform.rotation * Quaternion.Euler(0,moveDir.x,0), 10 * Time.deltaTime) ;
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), 50 * Time.deltaTime);
            //transform.rotation = new Quaternion(0,transform.rotation.y,0,0);
            //transform.Rotate(0, moveDir.x, 0);
        }
       
    }
    
}
