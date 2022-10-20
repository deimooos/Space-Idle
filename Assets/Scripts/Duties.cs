using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Duties : MonoBehaviour
{
    public static Duties scr;
    public float neededSteel = 0;
    public float neededSpring = 0;
    public float neededWrench = 0;
    public float neededGear = 0;
    public float neededBolts = 0;
    public float neededGasoline = 0;
    private void Awake()
    {
        scr = this; ;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        if(GlobalSettings.scr.steelCount >= neededSteel && GlobalSettings.scr.springCount >= neededSpring && GlobalSettings.scr.wrenchCount >= neededWrench && GlobalSettings.scr.gearCount >= neededGear && GlobalSettings.scr.boltsCount >= neededBolts && GlobalSettings.scr.gasolineCount >= neededGasoline)
        {
            transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.green;
            GlobalSettings.scr.endLevelButton.SetActive(true);
        }       
    }
    private void OnTriggerExit(Collider other)
    {
        transform.GetChild(0).gameObject.SetActive(false);
        GlobalSettings.scr.endLevelButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
