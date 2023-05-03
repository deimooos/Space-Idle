using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shed : MonoBehaviour
{
    public GameObject firstPos;
    public GameObject secondPos;
    public GameObject thirdPos;
    public GameObject parentObject;
    public List<GameObject> inShed;
    public int pose = 0;

    int floor = 0;
    public bool isLogShed = true;
    bool isGiving = false;
    bool isGetting = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void OnTriggerStay(Collider other)
    {
        if (!CharacterMove.scr.isRunning && GlobalSettings.scr.carries.Count > 0 && !isGetting)
        {
            if (GlobalSettings.scr.carries[0].GetComponent<Collect>().isLog && isLogShed)
            {
                for (int i = GlobalSettings.scr.carries.Count - 1; i >= 0; i--)
                {
                    StartCoroutine(permObjects(GlobalSettings.scr.carries[i]));
                }

            }
            else if (!GlobalSettings.scr.carries[0].GetComponent<Collect>().isLog && !isLogShed)
            {
                for (int i = GlobalSettings.scr.carries.Count - 1; i >= 0; i--)
                {
                    StartCoroutine(permObjects(GlobalSettings.scr.carries[i]));
                }
            }
        }
        else if (!CharacterMove.scr.isRunning && GlobalSettings.scr.carries.Count <=0 && inShed.Count>0 && !isGiving)
        {
            for (int i = inShed.Count-1; i >= 0; i--)
            {
                if (inShed.Count >0 && GlobalSettings.scr.carries.Count != GlobalSettings.scr.carryAmount)
                {
                    StartCoroutine(getShed(inShed[i]));
                }
            }
        
        
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isGiving = false;
        isGetting = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator permObjects(GameObject calledObject)
    {
        isGiving = true;
        GlobalSettings.scr.carries.Remove(calledObject);
        inShed.Add(calledObject);
        calledObject.transform.parent = parentObject.transform;
        //calledObject.transform.localScale = calledObject.transform.lossyScale;
        float elapsedTime = 0;
        float waitTime = 0.5f;
        Vector3 startPos =calledObject.transform.position;
        Quaternion startRot =calledObject.transform.localRotation;
        Quaternion endRot = Quaternion.identity;
        if (isLogShed)
        {
             endRot = Quaternion.identity * Quaternion.Euler(0, 90, 0);
        }
        else
        {

             endRot = Quaternion.identity * Quaternion.Euler(90, 30, -60);
        }
        Vector3 endPos=Vector3.zero;
        switch (pose)
        {
            case 0:
                endPos = 0.5f*Vector3.up + firstPos.transform.position + Vector3.up * floor / 2 ;
                break;
            case 1:
                endPos = 0.5f * Vector3.up + secondPos.transform.position + Vector3.up * floor /2;
                break;
            case 2:
                endPos = 0.5f * Vector3.up + thirdPos.transform.position + Vector3.up * floor / 2;
                break;
            default:
                break;
        }
        pose++;
        if (pose > 2)
        {
            pose = 0;
            floor++;
        }
        while (elapsedTime<waitTime)
        {
            calledObject.transform.position = Vector3.Slerp(startPos, endPos, elapsedTime / waitTime);
            calledObject.transform.localRotation = Quaternion.Slerp(startRot, endRot, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        calledObject.transform.position = endPos;
        if (GlobalSettings.scr.carries.Count <= 0)
        {
            //isWaiting = true;
            yield return new WaitForSeconds(2);
            isGiving = false;
        }
        yield return null;
    }
    IEnumerator getShed(GameObject calledObject)
    {
        isGetting = true;
        inShed.Remove(calledObject);
        GlobalSettings.scr.carries.Add(calledObject);
        
        calledObject.transform.parent = CharacterMove.scr.carrier.transform;
        calledObject.transform.localScale = calledObject.transform.lossyScale;
        float elapsedTime = 0;
        float waitTime = 0.5f;
        Vector3 startPos = calledObject.transform.localPosition;
        Vector3 endPos = Vector3.zero + GlobalSettings.scr.carries.Count * Vector3.up * 0.5f; ;
        Quaternion startRot = calledObject.transform.localRotation;
        Quaternion endRot = Quaternion.identity;
        if (isLogShed)
        {
            endRot = Quaternion.identity * Quaternion.Euler(0, 90, 0);
        }
        else
        {

            endRot = Quaternion.identity * Quaternion.Euler(90, 0, -60);
        }
        pose--;
        if (pose < 0)
        {
            pose = 2;
            floor--;
        }
        
        while (elapsedTime < waitTime)
        {
            calledObject.transform.localPosition = Vector3.Slerp(startPos, endPos, elapsedTime / waitTime);
            calledObject.transform.localRotation = Quaternion.Slerp(startRot, endRot, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        calledObject.transform.localPosition = endPos;
        if (GlobalSettings.scr.carries.Count == GlobalSettings.scr.carryAmount)
        {
            yield return new WaitForSeconds(2);
            isGetting = false;
        }
        yield return null;

    }
}
