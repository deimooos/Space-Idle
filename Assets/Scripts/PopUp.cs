using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(popUp(gameObject));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator popUp(GameObject build)
    {

        float elapsetTime = 0;
        float waitTime = 0.5f;
        Vector3 startScale = Vector3.zero;
        Vector3 endScale = build.transform.localScale;
        while (elapsetTime < waitTime)
        {
            build.transform.position = Vector3.Lerp(startScale, endScale, elapsetTime / waitTime);
            elapsetTime += Time.deltaTime;
            yield return null;
        }
        build.transform.localScale = endScale;
        yield return null;


    }
}
