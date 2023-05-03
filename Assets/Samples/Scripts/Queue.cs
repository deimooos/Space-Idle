using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
    public static Queue scr;
    public List<GameObject> inQueue;
    public GameObject spawnPoint;
    public GameObject endPoint;
    //public bool isAngry
    /*public Vector3 firstPos;
    public Vector3 secondPos;
    public Vector3 thirdPos;
    public Vector3 fourthPos;
    public Vector3 fifthPos;*/
    public bool inPosition = true;
    public bool canWantFood = true;
    public bool canWantDrink = true;

    private void Awake()
    {
        scr = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inQueue.Count < 5)
        {
            
            if(inPosition)
            {
                StartCoroutine(spawnCustomer());
            }
        
        }
    }
    IEnumerator spawnCustomer()
    {
        
        inPosition = false;
        GameObject customer = CustomerPool.SharedInstance.GetPooledObject();
        customer.GetComponent<Customer>().canWantFood = canWantFood;
        customer.GetComponent<Customer>().canWantDrink = canWantDrink;
        customer.GetComponent<Collider>().enabled = false;
        //customer.transform.position = spawnPoint.transform.position;
        customer.transform.parent = transform;
        customer.SetActive(true);
        inQueue.Add(customer);
        float elapsedTime = 0;
        float waitTime = 5f;
        Vector3 startPos = spawnPoint.transform.localPosition;
        Vector3 endPos = Vector3.zero + new Vector3(0,0,20* (inQueue.Count-1));
        
        while (elapsedTime < waitTime)
        {
            customer.transform.localPosition = Vector3.Slerp(startPos, endPos, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        customer.transform.localPosition = endPos;
        if(customer.transform.localPosition == Vector3.zero)
        {
            customer.GetComponent<Customer>().isWaiting = true;
            customer.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            customer.GetComponent<Collider>().enabled = true;
        }
        inPosition = true;
        yield return null;


       
    }
    IEnumerator goPoint(GameObject customer,int order)
    {
        float elapsedTime = 0;
        float waitTime = 0.5f;
        Vector3 startPos = customer.transform.localPosition;
        Vector3 endPos = Vector3.zero + new Vector3(0, 0, 20 * (order));

        while (elapsedTime < waitTime)
        {
            customer.transform.localPosition = Vector3.Slerp(startPos, endPos, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        customer.transform.localPosition = endPos;
        if (order == 0)
        {
            customer.GetComponent<Customer>().isWaiting = true;
            customer.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            customer.GetComponent<Collider>().enabled = true;
        }
        inPosition = true;
        yield return null;

    }

    public void reOrder()
    {
        StopAllCoroutines();
        for (int i = 0; i < inQueue.Count; i++)
        {

            StartCoroutine(goPoint(inQueue[i],i));
        }
    
    
    }
}
