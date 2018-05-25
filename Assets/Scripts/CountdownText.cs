using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class CountdownText : MonoBehaviour
{ 
    public delegate void CountdownFinished();
    public static event CountdownFinished OnCountdownFinished;

    float maxTime = 3f;
    public float timeLeft;
    public Text timeText;
    public GameObject timesUpText;

    public float timeStartDelay;
    

    private void OnEnable()
    {
        timesUpText.SetActive(false);
        timeLeft = maxTime;
        timeStartDelay = 1f;
    }

    void Start()
    {
    }

    // Countdown from 3 to 1
    void FixedUpdate()
    {
        if (timeLeft > 1)
        {
            timeLeft -= Time.deltaTime;
            timeText.text = timeLeft.ToString("F0");
        }
        else
        {
            timeText.text = "";
            CountdownDone();
        }
    }

    void CountdownDone()
    {

        // Delay for "start" text
        if (timeStartDelay > 0)
        {
            timesUpText.SetActive(true);
            timeStartDelay -= Time.deltaTime;
        }
        else
        {
            OnCountdownFinished();
        }
    }
}