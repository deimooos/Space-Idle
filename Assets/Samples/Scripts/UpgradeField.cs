using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeField : MonoBehaviour
{
    bool isOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(isOpened==false)
        { 
            openUpgrade(); 
        }

    }
    private void OnTriggerExit(Collider other)
    {
        isOpened = false;
        GlobalSettings.scr.upgradeCanvas.SetActive(false);
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void openUpgrade()
    {
        if (!CharacterMove.scr.isRunning)
        {
            isOpened = true;
          GlobalSettings.scr.upgradeCanvas.SetActive(true);
        }
    }
}
