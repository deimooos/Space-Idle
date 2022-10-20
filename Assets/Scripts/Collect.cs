using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public bool isLog = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GlobalSettings.scr.carries.Count < GlobalSettings.scr.carryAmount)
            {
                GetComponent<Collider>().enabled = false;
                if (GlobalSettings.scr.carries.Count == 0)
                {
                    GlobalSettings.scr.carries.Add(gameObject);
                    transform.parent = CharacterMove.scr.carrier.transform;
                    if (isLog)
                    {
                        StartCoroutine(sortLogs());
                    }
                    else
                    {
                        StartCoroutine(sortRocks());
                    }

                }
                else
                {
                    if ((isLog && GlobalSettings.scr.carries[0].GetComponent<Collect>().isLog))
                    {

                        GlobalSettings.scr.carries.Add(gameObject);
                        transform.parent = CharacterMove.scr.carrier.transform;
                        StartCoroutine(sortLogs());
                    }
                    if ((!isLog && !GlobalSettings.scr.carries[0].GetComponent<Collect>().isLog))
                    {
                        GlobalSettings.scr.carries.Add(gameObject);
                        transform.parent = CharacterMove.scr.carrier.transform;
                        StartCoroutine(sortRocks());
                    }

                }
            }
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator sortLogs()
    {
        float elapsetTime = 0;
        float waitTime = 0.5f;
        Vector3 startPos = gameObject.transform.localPosition;
        Vector3 endPos = Vector3.zero + GlobalSettings.scr.carries.Count * Vector3.up*0.5f;
        Quaternion startRot = gameObject.transform.localRotation;
        Quaternion endRot = Quaternion.identity*Quaternion.Euler(0,90,0);
        while (elapsetTime < waitTime)
        {
            gameObject.transform.localPosition = Vector3.Lerp(startPos, endPos, elapsetTime / waitTime);
            gameObject.transform.localRotation = Quaternion.Slerp(startRot, endRot, elapsetTime / waitTime);
            elapsetTime += Time.deltaTime;
            yield return null;
        }
        gameObject.transform.localPosition = endPos;
        gameObject.transform.localRotation = endRot;
        yield return null;
    }
    IEnumerator sortRocks()
    {
        float elapsetTime = 0;
        float waitTime = 0.5f;
        Vector3 startPos = gameObject.transform.localPosition;
        Vector3 endPos = Vector3.zero + GlobalSettings.scr.carries.Count * Vector3.up * 0.5f;
        Quaternion startRot = gameObject.transform.localRotation;
        Quaternion endRot = Quaternion.identity * Quaternion.Euler(90, 0,-60);
        while (elapsetTime < waitTime)
        {
            gameObject.transform.localPosition = Vector3.Slerp(startPos, endPos, elapsetTime / waitTime);
            gameObject.transform.localRotation = Quaternion.Slerp(startRot, endRot, elapsetTime / waitTime);
            elapsetTime += Time.deltaTime;
            yield return null;
        }
        gameObject.transform.localPosition = endPos;
        gameObject.transform.localRotation = endRot;
        yield return null;
    }
}
