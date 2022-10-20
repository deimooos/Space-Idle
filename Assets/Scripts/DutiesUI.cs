using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DutiesUI : MonoBehaviour
{
    public enum Supplies
    {
        gear,
        gasoline,
        wrench,
        bolts,
        spring,
        steel
    }
    public Supplies supplies = Supplies.gear;
    public bool isCurrent = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        switch(supplies)
        {
            case Supplies.gear:
                if (isCurrent == true)
                {
                    GetComponent<Text>().text = (GlobalSettings.scr.gearCount).ToString();
                    if(GlobalSettings.scr.gearCount>=Duties.scr.neededGear)
                    {
                        GetComponent<Text>().text = (Duties.scr.neededGear).ToString();
                    }
                }
                else
                {
                    GetComponent<Text>().text = (Duties.scr.neededGear).ToString();
                }
                
                break;
            case Supplies.bolts:
                if (isCurrent == true)
                {
                    GetComponent<Text>().text = (GlobalSettings.scr.boltsCount).ToString();
                    if (GlobalSettings.scr.boltsCount >= Duties.scr.neededBolts)
                    {
                        GetComponent<Text>().text = (Duties.scr.neededBolts).ToString();
                    }
                }
                else
                {
                    GetComponent<Text>().text = (Duties.scr.neededBolts).ToString();
                }

                break;
            case Supplies.spring:
                if (isCurrent == true)
                {
                    GetComponent<Text>().text = (GlobalSettings.scr.springCount).ToString();
                    if (GlobalSettings.scr.springCount >= Duties.scr.neededSpring)
                    {
                        GetComponent<Text>().text = (Duties.scr.neededSpring).ToString();
                    }
                }
                else
                {
                    GetComponent<Text>().text = (Duties.scr.neededSpring).ToString();
                }

                break;
            case Supplies.wrench:
                if (isCurrent == true)
                {
                    GetComponent<Text>().text = (GlobalSettings.scr.wrenchCount).ToString();
                    if (GlobalSettings.scr.wrenchCount >= Duties.scr.neededWrench)
                    {
                        GetComponent<Text>().text = (Duties.scr.neededWrench).ToString();
                    }
                }
                else
                {
                    GetComponent<Text>().text = (Duties.scr.neededWrench).ToString();
                }

                break;
            case Supplies.steel:
                if (isCurrent == true)
                {
                    GetComponent<Text>().text = (GlobalSettings.scr.steelCount).ToString();
                    if (GlobalSettings.scr.steelCount >= Duties.scr.neededSteel)
                    {
                        GetComponent<Text>().text = (Duties.scr.neededSteel).ToString();
                    }
                }
                else
                {
                    GetComponent<Text>().text = (Duties.scr.neededSteel).ToString();
                }

                break;
            case Supplies.gasoline:
                if (isCurrent == true)
                {
                    GetComponent<Text>().text = (GlobalSettings.scr.gasolineCount).ToString();
                    if (GlobalSettings.scr.gasolineCount >= Duties.scr.neededGasoline)
                    {
                        GetComponent<Text>().text = (Duties.scr.neededGasoline).ToString();
                    }
                }
                else
                {
                    GetComponent<Text>().text = (Duties.scr.neededGasoline).ToString();
                }

                break;
            default:
                break;


        }

    }
}
     
