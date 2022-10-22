using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public ParticleSystem axehit;
    public ParticleSystem pickaxehit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hitEffect()
    {
        axehit.Play();
        pickaxehit.Play();
    
    }




}
