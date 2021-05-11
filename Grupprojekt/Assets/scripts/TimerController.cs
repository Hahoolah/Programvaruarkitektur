using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    public Text timeCounter;
    private System.TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime;

   void Awake()
    {
        instance = this;
    }

     void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        timerGoing = false;
        BeginTimer();
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = System.TimeSpan.FromSeconds(elapsedTime);
            string timePlayingString = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingString;

            yield return null;
        }
    }

    public void ResetTime()
    {
        timePlaying = System.TimeSpan.FromSeconds(0);
        string timePlayingString = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
        timeCounter.text = timePlayingString;
    }
}


