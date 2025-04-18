using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkPool : MonoBehaviour
{
    public static DrinkPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.name = obj.name + i.ToString();
            obj.transform.parent = gameObject.transform;
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }



    public GameObject GetPooledObject()
    {
        //1
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //2
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        //3   
        return null;
    }
}
