using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeLevelText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.parent.parent.GetComponent<Upgrades>().upgradeCount< transform.parent.parent.GetComponent<Upgrades>().maxUpgradeAmount)
        {
            GetComponent<Text>().text = "LVL "+(transform.parent.parent.GetComponent<Upgrades>().upgradeCount+1).ToString();
        }
        else
        {
            GetComponent<Text>().text = "LVL MAX";
        }
    }
}
