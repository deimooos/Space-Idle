using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerUIProduct : MonoBehaviour
{
    public Sprite crystal;
    public Sprite drink;
    public Sprite food;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (transform.parent.parent.parent.parent.GetComponent<Customer>().randomOrder)
        {
            case 0:
                GetComponent<Image>().sprite = crystal;
                break;
            case 1:
                GetComponent<Image>().sprite = drink;
                break;
            case 2:
                GetComponent<Image>().sprite = food;
                break;
        }
    }
}
