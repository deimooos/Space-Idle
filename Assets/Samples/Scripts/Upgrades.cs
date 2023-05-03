using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public static Upgrades scr;
    public float maxUpgradeAmount = 5;
    public float axeDamageUpgradeAmount = 0;
    public float pickaxeDamageUpgradeAmount = 0;
    public float carryUpgradeAmount = 0;
    public float capacityUpgradeAmount = 0;
    public float upgradePrice=10;
    public float upgradeCount = 0;
    public enum PowerUps
    {
        axeDamage,
        pickaxeDamage,
        carryAmount,        
    }
    public PowerUps upgrades = PowerUps.axeDamage;

    private void Awake()
    {
        scr = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        switch (upgrades)
        {
            case PowerUps.axeDamage:
                upgradeCount = axeDamageUpgradeAmount;
                break;
            case PowerUps.carryAmount:
                upgradeCount = carryUpgradeAmount;
                break;
            case PowerUps.pickaxeDamage:
                upgradeCount = pickaxeDamageUpgradeAmount;
                break;
            default:

                break;
        }
        upgradePrice = 10 * (Mathf.Pow(2, upgradeCount));

    }
    public void upgradeCarryAmount()
    {
        if(GlobalSettings.scr.coin>=upgradePrice && carryUpgradeAmount<maxUpgradeAmount)
        {
            carryUpgradeAmount++;
            GlobalSettings.scr.carryAmount+=3;
            GlobalSettings.scr.coin -= upgradePrice;
        }
    }
    public void upgradeAxeDamage()
    {
        if (GlobalSettings.scr.coin >= upgradePrice && axeDamageUpgradeAmount< maxUpgradeAmount)
        {
            axeDamageUpgradeAmount++;
            GlobalSettings.scr.axeDamage += 5;
            GlobalSettings.scr.coin -= upgradePrice;
        }
    }
    public void upgradePickaxeDamage()
    {
        if (GlobalSettings.scr.coin >= upgradePrice && pickaxeDamageUpgradeAmount< maxUpgradeAmount)
        {
            pickaxeDamageUpgradeAmount++;
            GlobalSettings.scr.pickaxeDamage += 5;
            GlobalSettings.scr.coin -= upgradePrice;
        }
    }


}

