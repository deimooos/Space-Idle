using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollect : MonoBehaviour
{
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
            product.transform.position = Vector3.Lerp(startPos, CharacterMove.scr.transform.position + 2*Vector3.up, elapsetTime / waitTime);
            elapsetTime += Time.deltaTime;
            yield return null;
        }
        product.SetActive(false);
        yield return null;


    }
}
