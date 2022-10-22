using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollect : MonoBehaviour
{
    public bool canAnimate = true;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (transform.parent.GetComponent<Building>().type == Building.buildType.Mine)
        {
            GlobalSettings.scr.crystalCount += transform.parent.GetComponent<Building>().productCount;
            closeProducts();
            transform.parent.GetComponent<Building>().productCount = 0;
            //closeProducts();
        }
        else if (transform.parent.GetComponent<Building>().type == Building.buildType.Food)
        {
            GlobalSettings.scr.foodCount += transform.parent.GetComponent<Building>().productCount;
            closeProducts();
            transform.parent.GetComponent<Building>().productCount = 0;
           // closeProducts();
        }
        else if (transform.parent.GetComponent<Building>().type == Building.buildType.Drink)
        {
            GlobalSettings.scr.drinkCount += transform.parent.GetComponent<Building>().productCount;
            closeProducts();
            transform.parent.GetComponent<Building>().productCount = 0;
            
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    void closeProducts()
    {
        StartCoroutine(wait());
       /* for (int i = 0; i < transform.parent.GetComponent<Building>().products.Count; i++)
        {
            //transform.parent.GetComponent<Building>().products[i].SetActive(false);
        }*/
    }
    IEnumerator wait()
    {
        for (int i = 0; i < transform.parent.GetComponent<Building>().products.Count; i++)
        {
            StartCoroutine(goPlayer(transform.parent.GetComponent<Building>().products[i]));
            yield return new WaitForSeconds(0.15f);
            //transform.parent.GetComponent<Building>().products[i].SetActive(false);
        }
        yield return null;
    
    }
    IEnumerator goPlayer(GameObject product)
    {
        float elapsetTime = 0;
        float waitTime = 0.5f;
        Vector3 startPos = product.transform.position;
        //Vector3 endPos = log.transform.position + new Vector3(Random.Range(-4, 4), 0.5f, Random.Range(-4, 4));
        while (elapsetTime < waitTime)
        {
            product.transform.position = Vector3.Lerp(startPos, Camera.main.ScreenToWorldPoint(GlobalSettings.scr.colletiblesUI.transform.position)  ,elapsetTime / waitTime);
            elapsetTime += Time.deltaTime;
            yield return null;
        }
        product.transform.position = Camera.main.ScreenToWorldPoint(GlobalSettings.scr.colletiblesUI.transform.position);
        product.SetActive(false);
        transform.parent.GetComponent<Building>().products.Remove(product);
        if (canAnimate)
        StartCoroutine(popUp(GlobalSettings.scr.colletiblesUI));
        yield return null;


    }
    IEnumerator popUp(GameObject product)
    {
        float elapsetTime = 0;
        float waitTime = 0.1f;
        Vector3 startScale = product.transform.localScale;
        Vector3 endScale = startScale * 1.1f;
        canAnimate = false;

        //Vector3 endPos = log.transform.position + new Vector3(Random.Range(-4, 4), 0.5f, Random.Range(-4, 4));
        while (elapsetTime < waitTime)
        {
            product.transform.localScale = Vector3.Lerp(startScale, endScale, elapsetTime / waitTime);
            elapsetTime += Time.deltaTime;
            yield return null;
        }
        elapsetTime = 0;
        while (elapsetTime < waitTime)
        {
            product.transform.localScale = Vector3.Lerp(endScale, startScale, elapsetTime / waitTime);
            elapsetTime += Time.deltaTime;
            yield return null;
        }
        product.transform.localScale = startScale;
        canAnimate = true;

        
        yield return null;


    }
}
