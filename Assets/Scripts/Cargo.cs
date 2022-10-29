using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cargo : MonoBehaviour
{
    public List<Sprite> equipmentIcons;
    public GameObject target;
    public float steelCount = 0;
    public float price = 0;
    public float springCount = 0;
    public float wrenchCount = 0;
    public float gearCount = 0;
    public float boltsCount = 0;
    public float gasolineCount = 0;
    public enum Cargos
    {
        steel,
        spring,
        wrench,
        gear,
        bolts,
        gasoline,
    }
    public Cargos cargos = Cargos.steel;
    // Start is called before the first frame update
    void Start()
    {
        switch (cargos)
        {
            case Cargos.steel:
                price = 50;
              
                break;
            case Cargos.spring:
                price = 100;
           
                break;
            case Cargos.wrench:
                price = 200;
               
                break;
            case Cargos.gear:
                price = 30;
                
                break;
            case Cargos.bolts:
                price = 20;

                break;
            case Cargos.gasoline:
                price = 10;
                
                break;
            default:
                break;
        }
        
        

    }


    // Update is called once per frame
    void Update()
    {

    }
    public void steelAmount()
    {
        if (GlobalSettings.scr.coin >= price)
        {
            GlobalSettings.scr.steelCount++;
            if (GlobalSettings.scr.steelCount > 0)
            {
                GlobalSettings.scr.steel.SetActive(true);
            }
            //Order.scr.steelCount++;
            GlobalSettings.scr.coin -= price;
            getObject(equipmentIcons[1]);
            target = GlobalSettings.scr.steel.transform.GetChild(3).gameObject;
        }
        
    }
    public void springAmount()
    {
        if (GlobalSettings.scr.coin >= price)
        {
            GlobalSettings.scr.springCount++;
            if (GlobalSettings.scr.springCount > 0)
            {
                GlobalSettings.scr.spring.SetActive(true);
            }
            //Order.scr.springCount++;
            GlobalSettings.scr.coin -= price;
            getObject(equipmentIcons[2]);
            target = GlobalSettings.scr.spring.transform.GetChild(3).gameObject;
        }
       
    }
    public void wrenchAmount()
    {
        if (GlobalSettings.scr.coin >= price)
        {
            GlobalSettings.scr.wrenchCount++;
            if (GlobalSettings.scr.wrenchCount > 0)
            {
                GlobalSettings.scr.wrench.SetActive(true);
            }
            //Order.scr.wrenchCount++;
            GlobalSettings.scr.coin -= price;
            getObject(equipmentIcons[3]);
            target = GlobalSettings.scr.wrench.transform.GetChild(3).gameObject;
        }
    
    }
    public void gearAmount()
    {
        if (GlobalSettings.scr.coin >= price)
        {
            GlobalSettings.scr.gearCount++;
            if (GlobalSettings.scr.gearCount > 0)
            {
                GlobalSettings.scr.gear.SetActive(true);
            }
            //Order.scr.gearCount++;
            GlobalSettings.scr.coin -= price;
            getObject(equipmentIcons[0]);
            target = GlobalSettings.scr.gear.transform.GetChild(3).gameObject;
        }
      
    }
    public void boltsAmount()
    {
        if (GlobalSettings.scr.coin >= price)
        {
            GlobalSettings.scr.boltsCount++;
            if (GlobalSettings.scr.boltsCount > 0)
            {
                GlobalSettings.scr.bolts.SetActive(true);
            }
            //Order.scr.boltsCount++;
            GlobalSettings.scr.coin -= price;
            getObject(equipmentIcons[5]);
            target = GlobalSettings.scr.bolts.transform.GetChild(3).gameObject;
        }
       
    }
    public void gasolineAmount()
    {
        if (GlobalSettings.scr.coin >= price)
        {
            GlobalSettings.scr.gasolineCount++;
            if (GlobalSettings.scr.gasolineCount > 0)
            {
                GlobalSettings.scr.gasoline.SetActive(true);
            }
            //Order.scr.gasolineCount++;
            GlobalSettings.scr.coin -= price;
            getObject(equipmentIcons[4]);
            target = GlobalSettings.scr.gasoline.transform.GetChild(3).gameObject;
        }

    

    }

    public void getObject(Sprite iconType)
    {
        GameObject getEquipment = EquipmentPooler.SharedInstance.GetPooledObject();
        getEquipment.GetComponent<Image>().sprite = iconType;
        getEquipment.SetActive(true);
        StartCoroutine(goToUI(getEquipment));
    }
    public IEnumerator goToUI(GameObject icon)
    {
        float elapsetTime = 0;
        float waitTime = 0.5f;
        Vector3 startPos = gameObject.transform.position;
        Vector3 endPos = target.transform.position;

        while (elapsetTime < waitTime)
        {
            icon.transform.position = Vector3.Slerp(startPos, target.transform.position, elapsetTime / waitTime);
            elapsetTime += Time.deltaTime;
            yield return null;
        }
        icon.transform.position = endPos;
        icon.SetActive(false);
        yield return null;
    }
}

