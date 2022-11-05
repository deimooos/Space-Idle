using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deliver : MonoBehaviour
{/*
    public static Deliver scr;
    public bool isLanded = false;
    // Start is called before the first frame update
    private void Awake()
    {
        scr = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startDeliver()
    {
        StartCoroutine(deliver());
    
    }
    IEnumerator deliver()
    {
        
        isLanded = true;
        float elapsedTime = 0;
        float waitTime = 3;
        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(transform.position.x, 1.4f, transform.position.z);
        yield return new WaitForSeconds(10);
        while (elapsedTime < waitTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        elapsedTime = 0;
        transform.position = endPos;
        transform.parent.GetChild(1).gameObject.SetActive(true);
        while (elapsedTime < waitTime)
        {
            transform.position = Vector3.Lerp(endPos, startPos, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = startPos;
        
        //isLanded = false;
        /*isLanded = true;
        if (isLanded == true)
        {
            transform.parent.GetChild(1).gameObject.SetActive(true);
        }
        yield return null;
    }
    
    
}
*/
}