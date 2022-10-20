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
        food
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
            default:
                break;
        }
    }
}
