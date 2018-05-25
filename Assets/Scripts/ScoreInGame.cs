using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreInGame : MonoBehaviour
{
    public static int score;
    public Text scoreInGame;

    private void OnEnable()
    {
        score = 0;
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            score++;
        }
        // actual score in game
        scoreInGame.text = "" + score;
    }
}