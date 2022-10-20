using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventScript : MonoBehaviour
{
    /// <summary>
    /// Called when game starts
    /// </summary>
    public static void LevelStart()
    {
        StartCountLevelTime(true);
        Debug.Log("SA: Level Start");
    }

    /// <summary>
    /// Called when game ends
    /// </summary>
    public static void LevelEnd(bool win, int level)
    {
        //Debug.Log("SA: Level " + level + "(" + (level - 1) + ")" + " End: " + (win ? "COMPLETE" : "FAIL") + " in " + StartCountLevelTime(false) + "s");
    }
    public static void LevelEnd(bool win, int level,string reason,int stickmanCount,int enemyCount)
    {
        Debug.Log("Level " + level + " End: " + (win ? "COMPLETE" : "FAIL") + " with " +reason+ " in " + StartCountLevelTime(false) + "s"
            +"\n Stickman Count = "+stickmanCount + " Enemy Count = " + enemyCount);
    }
    public static void upgrade( string upgradeType, int level,  int cost)
    {
        Debug.Log(upgradeType + " level increased to " + level + " with " + cost + " gold ");
        //Debug.Log("SA: Level " + level + "(" + (level - 1) + ")" + " End: " + (win ? "COMPLETE" : "FAIL") + " in " + StartCountLevelTime(false) + "s");
    }
    public static void stickmanCollect(int stickmanCount,int cost,bool enemy)
    {
        Debug.Log("Stickman " + stickmanCount + " added " + (enemy ? "" : +cost + " with gold"));
        //Debug.Log("SA: Level " + level + "(" + (level - 1) + ")" + " End: " + (win ? "COMPLETE" : "FAIL") + " in " + StartCountLevelTime(false) + "s");
    }
    public static void feverMode(bool start,float time)
    {
        Debug.Log("Fever Mode " + (start ? " started " : " ended ")+time+"s length");
        //Debug.Log("SA: Level " + level + "(" + (level - 1) + ")" + " End: " + (start ? "started" : "ended") + " in " + StartCountLevelTime(false) + "s");
    }

    /// <summary>
    /// Time between two fades between scene change
    /// </summary>
    public static void NextScene()
    {
        //Debug.Log("SA: Next Scene");
        //if(SA.SaveData.level >= 1)
    }

    public static void GetReward(UnityAction action)
    {

    }

    /// <summary>
    /// Called between Scene "Load" to Scene "Game"
    /// </summary>
    public static void LoadSceneFinished()
    {
    }



















    private bool _startCountLevelTime;
    private float _levelTime;
    private static float StartCountLevelTime(bool start)
    {
        if (start)
        {
            eventScript._levelTime = 0;
        }
        eventScript._startCountLevelTime = start;
        return eventScript._levelTime;
    }

    private void LateUpdate()
    {
        if (_startCountLevelTime)
        {
            _levelTime += Time.unscaledDeltaTime;
        }
    }

    public static EventScript eventScript;

    private void Awake()
    {
        if (eventScript == null)
        {
            eventScript = this;
        }
        else
        {
            enabled = false;
            return;
        }
    }

    /// <summary>
    /// Shows banner
    /// </summary>
    public static void ShowBanner()
    {

    }

    /// <summary>
    /// Hides banner
    /// </summary>
    public static void HideBanner()
    {

    }
}
