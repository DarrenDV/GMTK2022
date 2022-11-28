using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Analytics : MonoBehaviour
{
    public float bulletHits = 0; //How many of the hits a player takes in a single game are caused by bullets?
    public bool fellInLava = false; //How many times does the player fall in lava?

    public float highScore = 0;
    public bool touchedWallOfDeath = false;

    public int round = 0;

    public UnityEvent roundEnd;


    public void Start()
    {
        roundEnd.AddListener(RoundEnd);
    }

    public void RoundEnd()
    {
        Debug.Log(highScore);
        Debug.Log(touchedWallOfDeath);

        //Add events in here
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "hitsByBullet", bulletHits },
            { "lavaFall", fellInLava},
            { "touchedWallOfDeath", touchedWallOfDeath},
            { "highScore", highScore},
            { "round", round}
        };

        Debug.Log(parameters);
            
        AnalyticsService.Instance.CustomData("roundEnd", parameters); 
        AnalyticsService.Instance.Flush();
        Debug.Log("Turd flushed");

        StartCoroutine(SceneSwitch());
    }

    private IEnumerator SceneSwitch()
    {
        //yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        yield return null;
    }

    public void OnDestroy()
    {
        roundEnd.RemoveListener(RoundEnd);
    }
}
