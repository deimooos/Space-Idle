using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public static Order scr;
    public float totalCount = 0;
    public float steelCount = 0;
    public float springCount = 0;
    public float wrenchCount = 0;
    public float gearCount = 0;
    public float boltsCount = 0;
    public float gasolineCount = 0;
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
        totalCount = steelCount + springCount + wrenchCount + gearCount + boltsCount + gasolineCount;
    }    
}
