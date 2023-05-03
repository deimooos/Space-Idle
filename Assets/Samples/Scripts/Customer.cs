using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    
    public int wantedAmount;
    public int randomOrder;
    bool isOnce = true;
    public bool isWaiting = false;
    public int coinAmount;
    public float totalTime = 0;
    public float waitTime = 20;
    public bool canWantFood = true;
    public bool canWantDrink = true;
    public enum orderType
    { 
    crystal,
    drink,
    food
    }
    public orderType order = orderType.crystal;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Collider>().enabled = false;
        isOnce = true;
        totalTime = 0;
        wantedAmount = Random.Range(5,21);
        if(!canWantFood && !canWantDrink)
        {
            randomOrder = 0;
        }
        else if(!canWantDrink)
        {
            randomOrder = Random.Range(0, 2);
        }
        else
        {
            randomOrder = Random.Range(0, 3);
        }
        coinAmount = wantedAmount * 5;
        switch (randomOrder)
        {
            case 0:
                order = orderType.crystal;
                break;
            case 1:
                order = orderType.drink;
                break;
            case 2:
                order = orderType.food;
                break;
        }
        switch (order)
        {
            case orderType.crystal:
                break;
            case orderType.drink:
                break;
            case orderType.food:
                break;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!CharacterMove.scr.isRunning && isOnce && other.gameObject.CompareTag("Player"))
        {
            
            switch (order)
            {
                case orderType.crystal:
                    if (GlobalSettings.scr.crystalCount >= wantedAmount)
                    {
                        isOnce = false;
                        GlobalSettings.scr.crystalCount -= wantedAmount;
                        GlobalSettings.scr.coin += coinAmount;
                        for (int i = 0; i < wantedAmount; i++)
                        {
                            GameObject coin = CoinPool.SharedInstance.GetPooledObject();
                            if (coin != null)
                            {
                                coin.transform.position = transform.position;
                                coin.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 180), 0);
                                //coin.GetComponent<Collider>().enabled = false;
                                coin.SetActive(true);
                                StartCoroutine(coinAnimation(coin));
                                
                            }
                        }
                        StartCoroutine(goPoint(Queue.scr.inQueue[0]));
                    }
                    break;
                case orderType.drink:
                    if (GlobalSettings.scr.drinkCount >= wantedAmount)
                    {
                        isOnce = false;
                        GlobalSettings.scr.drinkCount -= wantedAmount;
                        GlobalSettings.scr.coin += coinAmount;
                        for (int i = 0; i < wantedAmount; i++)
                        {
                            GameObject coin = CoinPool.SharedInstance.GetPooledObject();
                            if (coin != null)
                            {
                                coin.transform.position = transform.position;
                                coin.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 180), 0);
                                //coin.GetComponent<Collider>().enabled = false;
                                coin.SetActive(true);
                                StartCoroutine(coinAnimation(coin));

                            }
                        }
                        StartCoroutine(goPoint(Queue.scr.inQueue[0]));
                        //StartCoroutine(goPoint(Queue.scr.inQueue[0]));
                    }
                    break;
                case orderType.food:
                    if (GlobalSettings.scr.foodCount >= wantedAmount)
                    {
                        isOnce = false;
                        GlobalSettings.scr.foodCount -= wantedAmount;
                        GlobalSettings.scr.coin += coinAmount;
                        for (int i = 0; i < wantedAmount; i++)
                        {
                            GameObject coin = CoinPool.SharedInstance.GetPooledObject();
                            if (coin != null)
                            {
                                coin.transform.position = transform.position;
                                coin.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 180), 0);
                                //coin.GetComponent<Collider>().enabled = false;
                                coin.SetActive(true);
                                StartCoroutine(coinAnimation(coin));

                            }
                        }
                        StartCoroutine(goPoint(Queue.scr.inQueue[0]));
                        //StartCoroutine(goPoint(Queue.scr.inQueue[0]));
                    }
                    break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isWaiting)
        {
            totalTime += Time.deltaTime;
        }
        if (totalTime >= waitTime)
        {
            isWaiting = false;
            totalTime = 0;
            StartCoroutine(goPoint(Queue.scr.inQueue[0]));
        }
        
    }

    IEnumerator goPoint(GameObject customer)
    {
        customer.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        //Queue.scr.inQueue.RemoveAt(0);
        Queue.scr.inQueue.Remove(customer);
        Queue.scr.reOrder();
        float elapsedTime = 0;
        float waitTime = 3f;
        Vector3 startPos = customer.transform.localPosition;
        Vector3 endPos = Queue.scr.endPoint.transform.localPosition;

        while (elapsedTime < waitTime)
        {
            customer.transform.localPosition = Vector3.Lerp(startPos, endPos, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        customer.GetComponent<Collider>().enabled = false;
        isWaiting = false;
        isOnce = true;
        totalTime = 0;
        //isOnce = true;
        customer.SetActive(false);
        

        yield return null;

    }
    IEnumerator coinAnimation(GameObject coin)
    {


        float elapsetTime = 0;
        float waitTime = 0.5f;
        Vector3 startPos = coin.transform.position;
        Vector3 endPos = coin.transform.position + new Vector3(Random.Range(-4, 4), 2.5f, Random.Range(-4, 4));
        while (elapsetTime < waitTime)
        {
            coin.transform.position = Vector3.Slerp(startPos, endPos, elapsetTime / waitTime);
            elapsetTime += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(goPlayer(coin));
        //log.GetComponent<Collider>().enabled = true;
        yield return null;
    }
    IEnumerator goPlayer(GameObject coin)
    {
        float elapsetTime = 0;
        float waitTime = 1f;
        Vector3 startPos = coin.transform.position;
        Vector3 endPos = coin.transform.position + new Vector3(Random.Range(-4, 4), 0.5f, Random.Range(-4, 4));
        while (elapsetTime < waitTime)
        {
            coin.transform.position = Vector3.Slerp(startPos,CharacterMove.scr.transform.position + CharacterMove.scr.transform.up * 2, elapsetTime / waitTime);
            elapsetTime += Time.deltaTime;
            yield return null;
        }
        coin.SetActive(false);
        //log.GetComponent<Collider>().enabled = true;
        yield return null;

    }
}
