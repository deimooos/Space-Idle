using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakables : MonoBehaviour
{
    public float health=100;
    bool isHitting = false;
    public bool isTree = true;
    public int logCount = 5;
    bool isOnce = true;
    Animator animPlayer;
    // Start is called before the first frame update
    void Start()
    {
        animPlayer = CharacterMove.scr.transform.GetChild(0).GetComponent<Animator>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (gameObject.GetComponent<Collider>().enabled == true)
        {
            if (CharacterMove.scr.isRunning)
            {
                CharacterMove.scr.axe.SetActive(false);
                CharacterMove.scr.pickaxe.SetActive(false);
                animPlayer.SetBool("isCutting", false);
                animPlayer.SetBool("isMining", false);
                // CharacterMove.scr.transform.GetChild(0).GetComponent<Animator>().enabled = true;
            }
            if (!CharacterMove.scr.isRunning && !isHitting && isTree)
            {
                other.transform.LookAt(transform);
                //CharacterMove.scr.transform.GetChild(0).GetComponent<Animator>().enabled = false;
                CharacterMove.scr.axe.SetActive(true);
                animPlayer.SetBool("isCutting", true);
                StartCoroutine(hit());
                health -= GlobalSettings.scr.axeDamage;
            }
            if (!CharacterMove.scr.isRunning && !isHitting && !isTree)
            {
                other.transform.LookAt(transform);
                // CharacterMove.scr.transform.GetChild(0).GetComponent<Animator>().enabled = false;
                CharacterMove.scr.pickaxe.SetActive(true);
                animPlayer.SetBool("isMining", true);
                StartCoroutine(hit());
                health -= GlobalSettings.scr.pickaxeDamage;
            }
        }
        else
        {
            animPlayer.SetBool("isCutting", false);
            animPlayer.SetBool("isMining", false);
            //CharacterMove.scr.transform.GetChild(0).GetComponent<Animator>().enabled = true;
            CharacterMove.scr.axe.SetActive(false);
            CharacterMove.scr.pickaxe.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        animPlayer.SetBool("isCutting", false);
        animPlayer.SetBool("isMining", false);
        //CharacterMove.scr.transform.GetChild(0).GetComponent<Animator>().enabled = true;
        CharacterMove.scr.axe.SetActive(false);
        CharacterMove.scr.pickaxe.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (health<=0 && isTree && isOnce)
        {
            isOnce = false;
            gameObject.GetComponent<Renderer>().enabled = false;
            //gameObject.GetComponent<Collider>().enabled = false;
            foreach (Collider c in GetComponents<Collider>())
            {
                c.enabled = false;
            }
            transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            StartCoroutine(logs());
            animPlayer.SetBool("isCutting", false);
            animPlayer.SetBool("isMining", false);
            //CharacterMove.scr.transform.GetChild(0).GetComponent<Animator>().enabled = true;
            CharacterMove.scr.axe.SetActive(false);
            CharacterMove.scr.pickaxe.SetActive(false);
        }
        if (health <= 0 && !isTree && isOnce)
        {
            isOnce = false;
            gameObject.GetComponent<Renderer>().enabled = false;
            //gameObject.GetComponent<Collider>().enabled = false;
            foreach (Collider c in GetComponents<Collider>())
            {
                c.enabled = false;
            }
            transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            StartCoroutine(rocks());
            animPlayer.SetBool("isCutting", false);
            animPlayer.SetBool("isMining", false);
            //CharacterMove.scr.transform.GetChild(0).GetComponent<Animator>().enabled = true;
            CharacterMove.scr.axe.SetActive(false);
            CharacterMove.scr.pickaxe.SetActive(false);

        }
    }

    IEnumerator hit()
    {
        isHitting = true;
        float elapsetTime = 0;
        float waitTime = 1;
        while (elapsetTime<waitTime)
        {
            elapsetTime += Time.deltaTime;
            yield return null;
        }
        isHitting = false;
        yield return null;
    }
    IEnumerator logs()
    {
        for (int i = 0; i < logCount; i++)
        {
            GameObject log = LogPool.SharedInstance.GetPooledObject();
            if (log != null)
            {
                log.transform.position = transform.position;
                log.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 180), 0);
                log.GetComponent<Collider>().enabled = false;
                log.GetComponent<MeshRenderer>().sharedMaterial = GetComponent<MeshRenderer>().sharedMaterial;
                log.SetActive(true);
                StartCoroutine(logAnimation(log));
                yield return null;
            }
        }
        yield return null;
    }
    IEnumerator rocks()
    {
        for (int i = 0; i < logCount; i++)
        {
            GameObject rock = RockPool.SharedInstance.GetPooledObject();
            if (rock != null)
            {
                rock.transform.position = transform.position;
                rock.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 180), 0);
                rock.GetComponent<Collider>().enabled = false;
                rock.GetComponent<MeshRenderer>().sharedMaterial = GetComponent<MeshRenderer>().sharedMaterial;
                rock.SetActive(true);
                StartCoroutine(logAnimation(rock));
                yield return null;
            }
        }
        yield return null;
    }
    IEnumerator logAnimation(GameObject log)
    {

        
        float elapsetTime = 0;
        float waitTime = 0.5f;
        Vector3 startPos = log.transform.position;
        Vector3 endPos = log.transform.position + new Vector3(Random.Range(-4, 4), 0.5f, Random.Range(-4, 4));
        while (elapsetTime < waitTime)
        {
            log.transform.position = Vector3.Slerp(startPos,endPos ,elapsetTime/waitTime);
            elapsetTime += Time.deltaTime;
            yield return null;
        }
        log.GetComponent<Collider>().enabled = true;
        yield return null;
    }
}
