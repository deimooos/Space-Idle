using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StandardAssets;

public class Rocket : MonoBehaviour
{
    public ParticleSystem fire;
    public ParticleSystem ember;
    public static Rocket scr;
    public bool isLanded = false;
    // Start is called before the first frame update
    private void Awake()
    {
        scr = this;
    }
    void Start()
    {
        CameraFollow.scr.Target = GameObject.Find("Rocket").transform;
        CameraFollow.scr.Offset.x = -2;
        StartCoroutine(landing());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void callingCoroutine()
    {
        GlobalSettings.scr.gameFinished = true;
        StartCoroutine(flying());
        StartCoroutine(wait());
    }
    IEnumerator landing()
    {
        float elapsedTime = 0;
        float waitTime = 1.5f;
        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(transform.position.x, 0.7f, transform.position.z);
        while (elapsedTime < waitTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // GlobalSettings.scr.player.GetComponent<MeshRenderer>.SetActive(true);
        CameraFollow.scr.Offset.x = 0;
        GameObject.Find("Player").transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = true ;
        GameObject.Find("Player").transform.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
        CharacterMove.scr.enabled = true;
        CameraFollow.scr.targetC = false;
        elapsedTime = 0;
        while (elapsedTime < 0.5f)
        {
            Vector3 targetPosition = GameObject.Find("Player").transform.position + CameraFollow.scr.Offset;
            CameraFollow.scr.camTransform.position = Vector3.Lerp(CameraFollow.scr.camTransform.position, targetPosition, elapsedTime/waitTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        CameraFollow.scr.Target = GameObject.Find("Player").transform;
        CameraFollow.scr.targetC = true;
        isLanded = true;
        fire.enableEmission = false;
        ember.enableEmission = false;
        //fire.Stop();
        yield return null;

    }
    IEnumerator flying()
    {
        fire.enableEmission = true;
        ember.enableEmission = true;
        GameObject.Find("Player").transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = false;
        float elapsedTime = 0;
        float waitTime = 3;
        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(transform.position.x, 30, transform.position.z);
        while (elapsedTime < waitTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        //GlobalSettings.scr.player.SetActive(true);
        isLanded = true;
        yield return null;

    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        SA.EndGame(true);
    }
}
