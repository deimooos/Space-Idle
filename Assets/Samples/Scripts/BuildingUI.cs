using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    public bool isLog = true;
    public bool isCurrent = true;
    public float currentAmount;
    public int neededWood = 0;
    public int neededRock = 0;
    public int neededWoodLv2 = 0;
    public int neededRockLv2 = 0;
    public int neededWoodLv3 = 0;
    public int neededRockLv3 = 0;

    // Start is called before the first frame update
    void Start()
    {
        neededRock = transform.parent.parent.parent.parent.GetComponent<Building>().neededRock;
        neededRockLv2 = transform.parent.parent.parent.parent.GetComponent<Building>().neededRockLv2;
        neededRockLv3 = transform.parent.parent.parent.parent.GetComponent<Building>().neededRockLv3;
        neededWood = transform.parent.parent.parent.parent.GetComponent<Building>().neededWood;
        neededWoodLv2 = transform.parent.parent.parent.parent.GetComponent<Building>().neededWoodLv2;
        neededWoodLv3 = transform.parent.parent.parent.parent.GetComponent<Building>().neededWoodLv3;


    }

    // Update is called once per frame
    void Update()
    {
        /*if (isLog && isCurrent)
        {
            if (transform.parent.parent.parent.GetComponent<Building>().level == 0)
            {
                GetComponent<Text>().text = (neededWood - transform.parent.parent.parent.GetComponent<Building>().neededWood).ToString();
            }
            else if (transform.parent.parent.parent.GetComponent<Building>().level == 1)
            {
                GetComponent<Text>().text = (neededWoodLv2 - transform.parent.parent.parent.GetComponent<Building>().neededWoodLv2).ToString();
            }
            else if (transform.parent.parent.parent.GetComponent<Building>().level == 2)
            {
                GetComponent<Text>().text = (neededWoodLv3 - transform.parent.parent.parent.GetComponent<Building>().neededWoodLv3).ToString();
            }
        }
        else if(!isLog && isCurrent)
        {
            if (transform.parent.parent.parent.GetComponent<Building>().level == 0)
            {
                GetComponent<Text>().text = (neededRock - transform.parent.parent.parent.GetComponent<Building>().neededRock).ToString();
            }
            else if (transform.parent.parent.parent.GetComponent<Building>().level == 1)
            {
                GetComponent<Text>().text = (neededRockLv2 - transform.parent.parent.parent.GetComponent<Building>().neededRockLv2).ToString();
            }
            else if (transform.parent.parent.parent.GetComponent<Building>().level == 2)
            {
                GetComponent<Text>().text = (neededRockLv3 - transform.parent.parent.parent.GetComponent<Building>().neededRockLv3).ToString();
            }
        }
        else if (!isLog && !isCurrent)
        {
            if (transform.parent.parent.parent.GetComponent<Building>().level == 0)
            {
                GetComponent<Text>().text = neededRock.ToString();
            }
            else if (transform.parent.parent.parent.GetComponent<Building>().level == 1)
            {
                GetComponent<Text>().text = neededRockLv2.ToString();
            }
            else if (transform.parent.parent.parent.GetComponent<Building>().level == 2)
            {
                GetComponent<Text>().text = neededRockLv3.ToString();
            }
        }
        else if (isLog && !isCurrent)
        {
            if (transform.parent.parent.parent.GetComponent<Building>().level == 0)
            {
                GetComponent<Text>().text = neededWood.ToString();
            }
            else if (transform.parent.parent.parent.GetComponent<Building>().level == 1)
            {
                GetComponent<Text>().text = neededWoodLv2.ToString();
            }
            else if (transform.parent.parent.parent.GetComponent<Building>().level == 2)
            {
                GetComponent<Text>().text = neededWoodLv3.ToString();
            }
        }*/

        if(isLog)
        {
            if (transform.parent.parent.parent.parent.GetComponent<Building>().level == 0)
            {
                GetComponent<Text>().text = transform.parent.parent.parent.parent.GetComponent<Building>().neededWood.ToString();
            }
            else if (transform.parent.parent.parent.parent.GetComponent<Building>().level == 1)
            {
                GetComponent<Text>().text = transform.parent.parent.parent.parent.GetComponent<Building>().neededWoodLv2.ToString();
            }
            else if (transform.parent.parent.parent.parent.GetComponent<Building>().level == 2)
            {
                GetComponent<Text>().text = transform.parent.parent.parent.parent.GetComponent<Building>().neededWoodLv3.ToString();
            }
        }
        else
        {
            if (transform.parent.parent.parent.parent.GetComponent<Building>().level == 0)
            {
                GetComponent<Text>().text = transform.parent.parent.parent.parent.GetComponent<Building>().neededRock.ToString();
            }
            else if (transform.parent.parent.parent.parent.GetComponent<Building>().level == 1)
            {
                GetComponent<Text>().text = transform.parent.parent.parent.parent.GetComponent<Building>().neededRockLv2.ToString();
            }
            else if (transform.parent.parent.parent.parent.GetComponent<Building>().level == 2)
            {
                GetComponent<Text>().text = transform.parent.parent.parent.parent.GetComponent<Building>().neededRockLv3.ToString();
            }
        }
    }
}
