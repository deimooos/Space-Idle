using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    void Start()
    {
        slider = slider.GetComponent<Slider>();
    }

    void Update()
    {
        
    }
}
