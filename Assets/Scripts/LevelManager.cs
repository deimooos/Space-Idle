using StandardAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int levelCount;
    public int[] tutorialLevels;
    [Space(16)]
    public bool Testing;
    public List<int> lvl;
    public GameObject TestLevel;
   
    private void Start()
    {
        SetValues();
        SpawnLevel();
    }
    private void SetValues()
    {
        for (int i = 0; i < levelCount; i++)
        {
            lvl.Add(i + 1);
        }
        if ((SA.SaveData.level + 1) >= lvl.Count)
        {
            for (int i = 0; i < tutorialLevels.Length; i++)
            {
                lvl.Remove(tutorialLevels[i]);
            }
        }
    }    
    private void SpawnLevel()
    {
        if (!Testing)
        {
            int index = lvl[SA.SaveData.level % lvl.Count];
            GameObject obj = Resources.Load<GameObject>("Level/Level " + index);
            Instantiate(obj);
        }
        else
        {
            Debug.LogWarning("Test level loaded.");
            GameObject obj = TestLevel;
            Instantiate(obj);
        }
    }
}
