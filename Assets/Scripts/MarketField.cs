using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketField : MonoBehaviour
{
    bool isOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (!Deliver.scr.isLanded && !CharacterMove.scr.isRunning)
        {
            if(isOpened==false)
            {
                isOpened = true;
                GlobalSettings.scr.marketCanvas.SetActive(true); 
            }
            
        }

    }
    private void OnTriggerExit(Collider other)
    {
        isOpened = false;
        GlobalSettings.scr.marketCanvas.SetActive(false);
        if(Order.scr.totalCount>0 && !Deliver.scr.isLanded)
        {
            Deliver.scr.startDeliver();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
