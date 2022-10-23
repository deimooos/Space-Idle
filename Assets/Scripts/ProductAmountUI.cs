using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductAmountUI : MonoBehaviour
{
    // Start is called before the first frame update
    public enum productType
    {
        crystal,
        drink,
        food,
        gear,
        steel,
        spring,
        wrench,
        gasoline,
        bolts
    }
    public productType product = productType.crystal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (product)
        {
            case productType.crystal:
                GetComponent<Text>().text = GlobalSettings.scr.crystalCount.ToString();
                break;
            case productType.drink:
                GetComponent<Text>().text = GlobalSettings.scr.drinkCount.ToString();
                break;
            case productType.food:
                GetComponent<Text>().text = GlobalSettings.scr.foodCount.ToString();
                break;
            case productType.steel:
                GetComponent<Text>().text = GlobalSettings.scr.steelCount.ToString();
                break;
            case productType.gear:
                GetComponent<Text>().text = GlobalSettings.scr.gearCount.ToString();
                break;
            case productType.spring:
                GetComponent<Text>().text = GlobalSettings.scr.springCount.ToString();
                break;
            case productType.wrench:
                GetComponent<Text>().text = GlobalSettings.scr.wrenchCount.ToString();
                break;
            case productType.gasoline:
                GetComponent<Text>().text = GlobalSettings.scr.gasolineCount.ToString();
                break;
            case productType.bolts:
                GetComponent<Text>().text = GlobalSettings.scr.boltsCount.ToString();
                break;


            default:
                break;
        }
    }
}
