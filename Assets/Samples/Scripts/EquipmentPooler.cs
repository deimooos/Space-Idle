using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPooler : MonoBehaviour
{
    public static EquipmentPooler SharedInstance;
    public List<GameObject> pooledEquipments;
    public GameObject equipmentToPool;
    public int amountToPool;
    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledEquipments = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(equipmentToPool);
            obj.name = obj.name + i.ToString();
            obj.transform.parent = gameObject.transform;
            obj.SetActive(false);
            pooledEquipments.Add(obj);
        }
    }



    public GameObject GetPooledObject()
    {
        //1
        for (int i = 0; i < pooledEquipments.Count; i++)
        {
            //2
            if (!pooledEquipments[i].activeInHierarchy)
            {
                return pooledEquipments[i];
            }
        }
        //3   
        return null;
    }
}
