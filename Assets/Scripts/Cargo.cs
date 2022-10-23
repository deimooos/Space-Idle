using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{
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
        switch(cargos)
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
        if(GlobalSettings.scr.coin>=price)
        {
            GlobalSettings.scr.steelCount++;
            if (GlobalSettings.scr.steelCount > 0)
            {
                GlobalSettings.scr.steel.SetActive(true);
            }
            //Order.scr.steelCount++;
            GlobalSettings.scr.coin -= price;
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
        }
    }
   
}

