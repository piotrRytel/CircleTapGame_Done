using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerInGame : MonoBehaviour
{
    public delegate void CountdownFinished();
    public static event CountdownFinished OnTimeOver;

    public Image fillImg;
    float time;
    float timeAmt = 10f;
    public Text timeText;

    void Start()
    {
    }

    void OnEnable()
    {
        time = timeAmt;
    }

    // timer in game
    void FixedUpdate()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            UnFillImg();
        }
        else
        {
            OnTimeOver();
        }
    }
   
    // Timer in progres bar and time text format: 0,00
    public void UnFillImg()
    {
     fillImg.fillAmount = time / timeAmt;
     timeText.text = time.ToString("F2");
    }
    
}
