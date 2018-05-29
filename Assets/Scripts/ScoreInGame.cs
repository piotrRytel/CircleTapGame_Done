using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreInGame : MonoBehaviour
{
    public Text scoreInGameText;


    public void Update()
    {
        // actual score in game
        scoreInGameText.text = "" + Circle.score;
    }

}
