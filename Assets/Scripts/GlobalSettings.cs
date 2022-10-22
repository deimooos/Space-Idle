using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    public GameObject colletiblesUI;
    public int foodCount=0;
    public int drinkCount=0;
    public int crystalCount=0;
    public float coin = 0;
    public GameObject player;
    public GameObject upgradeCanvas;
    public GameObject marketCanvas;
    public GameObject endLevelButton;
    public static GlobalSettings scr;
    public float moveSpeed;
    public float axeDamage;
    public float pickaxeDamage;
    public int carryAmount;
    public List<GameObject> carries;
    public float steelCount = 0;
    public float springCount = 0;
    public float wrenchCount = 0;
    public float gearCount = 0;
    public float boltsCount = 0;
    public float gasolineCount = 0;
    public bool gameFinished = false;
   
    // Start is called before the first frame update
    private void Awake()
    {
        scr = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
