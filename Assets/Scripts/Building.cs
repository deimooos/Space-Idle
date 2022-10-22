using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public bool isWaiting = false;
    public int level1needed;
    public int level2needed;
    public int level3needed;
    public GameObject slider;
    public List<GameObject> products;
    public GameObject food;
    public GameObject drink;
    public GameObject crystal;
    public GameObject productType;
    public GameObject productTarget;
    public GameObject firstPosition;
    public GameObject secondPosition;
    public GameObject thirdPosition;
    public GameObject fourthPosition;
    public GameObject fifthPosition;
    public GameObject neededUI;
    public bool canBeLevelThree = true;
    public bool canBeLevelTwo = true;
    public int productAmount = 5;
    public int productCount = 0;
    public float productTime = 10;
    public float productElapsetTime = 0;
    public int neededWood = 10;
    public int neededRock = 0; 
    public int neededWoodLv2 = 20;
    public int neededRockLv2 = 20;
    public int neededWoodLv3 = 40;
    public int neededRockLv3 = 30;
    public int level = 0;
    public enum buildType
    { 
     Mine,
     Food,
     Drink
    }
    public buildType type;


    // Start is called before the first frame update
    void Start()
    {
        level1needed = neededWood + neededRock;
        level2needed = neededWoodLv2 + neededRockLv2;
        level3needed = neededWoodLv3 + neededRockLv3;

        switch (type)
        {
            case buildType.Mine:
                productType = crystal;
                break;
            case buildType.Food:
                productType = food;
                break;
            case buildType.Drink:
                productType = drink;
                break;


        }
    }
    private void OnTriggerStay(Collider other)      
    {
        if (GlobalSettings.scr.carries.Count > 0 && !CharacterMove.scr.isRunning)
        {
            if (level == 0)
            {
                if (GlobalSettings.scr.carries[0].GetComponent<Collect>().isLog && neededWood > 0)
                {
                    StartCoroutine(wait());
                    /*for (int i = GlobalSettings.scr.carries.Count-1; i >= 0; i--)
                    {
                        StartCoroutine(give(GlobalSettings.scr.carries[i]));
                        neededWood--;
                    }*/
                }
                else if (!GlobalSettings.scr.carries[0].GetComponent<Collect>().isLog && neededRock > 0)
                {
                    StartCoroutine(wait());
                    /*for (int i = GlobalSettings.scr.carries.Count - 1; i >= 0; i--)
                    {
                        StartCoroutine(give(GlobalSettings.scr.carries[i]));
                        neededRock--;
                    }*/
                }
            }
            if (level == 1)
            {
                if (GlobalSettings.scr.carries[0].GetComponent<Collect>().isLog && neededWoodLv2 > 0)
                {
                    StartCoroutine(wait());
                    /*for (int i = GlobalSettings.scr.carries.Count - 1; i >= 0; i--)
                    {
                        StartCoroutine(give(GlobalSettings.scr.carries[i]));
                        neededWoodLv2--;
                    }*/
                }
                else if (!GlobalSettings.scr.carries[0].GetComponent<Collect>().isLog && neededRockLv2 > 0)
                {
                    StartCoroutine(wait());
                    /*for (int i = GlobalSettings.scr.carries.Count - 1; i >= 0; i--)
                    {
                        StartCoroutine(give(GlobalSettings.scr.carries[i]));
                        neededRockLv2--;
                    }*/
                }
            }
            if (level == 2)
            {
               if (GlobalSettings.scr.carries[0].GetComponent<Collect>().isLog && neededWoodLv3 > 0)
                {
                    StartCoroutine(wait());
                    /*for (int i = GlobalSettings.scr.carries.Count - 1; i >= 0; i--)
                    {
                        StartCoroutine(give(GlobalSettings.scr.carries[i]));
                        neededWoodLv3--;
                    }*/
                }
                else if (!GlobalSettings.scr.carries[0].GetComponent<Collect>().isLog && neededRockLv3 > 0)
                {
                    StartCoroutine(wait());
                    /*for (int i = GlobalSettings.scr.carries.Count - 1; i >= 0; i--)
                    {
                        StartCoroutine(give(GlobalSettings.scr.carries[i]));
                        neededRockLv3--;
                    }*/
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (level == 1 && !canBeLevelTwo)
        {
           
            transform.GetComponent<Collider>().enabled = false;
            neededUI.SetActive(false);
        }
        if (level == 2 && !canBeLevelThree)
        {
            
            transform.GetComponent<Collider>().enabled = false;
            neededUI.SetActive(false);
        }
        if (level == 3)
        {
            
            transform.GetComponent<Collider>().enabled = false;
            neededUI.SetActive(false);
        }
        if (neededWood<=0 && neededRock <=0 && level==0)
        {

            level = 1;
        }
        else if (neededWoodLv2<=0 && neededRockLv2 <=0 && level==1)
        {
            level = 2;
        }
        else if (neededWoodLv3<=0 && neededRockLv3 <=0 && level==2)
        {
            level = 3;
        }
        if (level==0)
        {
              slider.GetComponent<Slider>().value =(float) (level1needed-(neededWood + neededRock))/level1needed;
        }
        else if (level==1)
        {
            slider.GetComponent<Slider>().value = (float)(level2needed-(neededWoodLv2 + neededRockLv2))/level2needed ;
            transform.GetChild(0).gameObject.SetActive(true);
            productAmount = 5;
            productTime = 5;
        }
        else if (level==2)
        {
            slider.GetComponent<Slider>().value = (float)(level3needed - (neededWoodLv3 + neededRockLv3))/level3needed;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            productAmount = 10;
            productTime = 3;
        }
        else if (level==3)
        {
         
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            productAmount = 20;
            productTime = 1;
        }
        if (productCount<productAmount && level>=1)
        {           
            if(productElapsetTime>productTime)
            {
                productCount++;
                StartCoroutine(sortProduct());               
                productElapsetTime = 0;
            }
            else
            {
                productElapsetTime += Time.deltaTime;
            }
        }

    }
    IEnumerator wait()
    {
        if (GlobalSettings.scr.carries[0] != null && !isWaiting)
        {
            isWaiting = true;
            for (int i = GlobalSettings.scr.carries.Count - 1; i >= 0; i--)
            {
                if (GlobalSettings.scr.carries.Count>0)
                {
                    if (level == 0)
                    {
                        if (GlobalSettings.scr.carries[0].GetComponent<Collect>().isLog && neededWood > 0)
                        {
                            StartCoroutine(give(GlobalSettings.scr.carries[i]));
                            neededWood--;
                            yield return new WaitForSeconds(0.1f);


                        }
                        else if (!GlobalSettings.scr.carries[0].GetComponent<Collect>().isLog && neededRock > 0)
                        {
                            StartCoroutine(give(GlobalSettings.scr.carries[i]));
                            neededRock--;
                            yield return new WaitForSeconds(0.1f);
                        }
                    }
                    if (level == 1)
                    {
                        if (GlobalSettings.scr.carries[0].GetComponent<Collect>().isLog && neededWoodLv2 > 0)
                        {
                            StartCoroutine(give(GlobalSettings.scr.carries[i]));
                            neededWoodLv2--;
                            yield return new WaitForSeconds(0.1f);
                        }
                        else if (!GlobalSettings.scr.carries[0].GetComponent<Collect>().isLog && neededRockLv2 > 0)
                        {
                            StartCoroutine(give(GlobalSettings.scr.carries[i]));
                            neededRockLv2--;
                            yield return new WaitForSeconds(0.1f);
                        }
                    }
                    if (level == 2)
                    {
                        if (GlobalSettings.scr.carries[0].GetComponent<Collect>().isLog && neededWoodLv3 > 0)
                        {
                            StartCoroutine(give(GlobalSettings.scr.carries[i]));
                            neededWoodLv3--;
                            yield return new WaitForSeconds(0.1f);
                        }
                        else if (!GlobalSettings.scr.carries[0].GetComponent<Collect>().isLog && neededRockLv3 > 0)
                        {
                            StartCoroutine(give(GlobalSettings.scr.carries[i]));
                            neededRockLv3--;
                            yield return new WaitForSeconds(0.1f);

                        }
                    }
                }
                    //StartCoroutine(give(GlobalSettings.scr.carries[i]));
                    yield return new WaitForSeconds(0.15f);
                isWaiting = false;
            }
        }
        yield return null;
    }
    IEnumerator give(GameObject buildObject)
    {
        GlobalSettings.scr.carries.Remove(buildObject);
        buildObject.transform.parent = LogPool.SharedInstance.transform;
        float elapsetTime = 0;
        float waitTime = 0.5f;
        Vector3 startPos = buildObject.transform.position+Vector3.up*3.5f;
        Vector3 endPos = productTarget.transform.position;
        while (elapsetTime < waitTime)
        {
            buildObject.transform.position = Vector3.Slerp(startPos, endPos, elapsetTime / waitTime);
            elapsetTime += Time.deltaTime;
            yield return null;
        }
        buildObject.transform.position = endPos;
        buildObject.SetActive(false);
        buildObject.GetComponent<Collider>().enabled = true;
        yield return null;
    }
    IEnumerator sortProduct()
    {
        switch (type)
        {
            case buildType.Mine:
                productType = CrystalPool.SharedInstance.GetPooledObject();
                break;
            case buildType.Food:
                productType = FoodPool.SharedInstance.GetPooledObject();
                break;
            case buildType.Drink:
                productType = DrinkPool.SharedInstance.GetPooledObject();
                break;


        }
        products.Add(productType);
        productType.SetActive(true);
        float elapsetTime = 0;
        float waitTime = 0.5f;
        Vector3 startPos = productTarget.transform.position;
        Vector3 endPos = transform.position+transform.forward*4+Vector3.up*productCount;
        switch(productCount % 5)
        {
            case 0:
                endPos = fifthPosition.transform.position;
                break;
            case 1:
                endPos = firstPosition.transform.position;
                break;
            case 2:
                endPos = secondPosition.transform.position;
                break;
            case 3:
                endPos = thirdPosition.transform.position;
                break;
            case 4:
                endPos = fourthPosition.transform.position;
                break;
            default:
                break;
        }
        endPos += Vector3.up * Mathf.Floor((productCount-1) / 5) * 1.5f;
        while (elapsetTime<waitTime)
        {
            productType.transform.position = Vector3.Lerp(startPos, endPos, elapsetTime / waitTime);
            elapsetTime += Time.deltaTime;
            yield return null;
        }
        productType.transform.position = endPos;
        yield return null;
    }
    
}
