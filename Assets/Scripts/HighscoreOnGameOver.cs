using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreOnGameOver : MonoBehaviour {
    public static HighscoreOnGameOver Instance;

    public Text lastGameScore;
    int scoreLast;
    public Text highscoreBestText;
    public Text highscoreStartText;

    public AudioSource highscoreSound;
    public AudioSource looseSound;

    void OnEnable() {
        Wynik();
    }


    // Update is called once per frame
    void Update () {
    }

    public void Wynik()
    {
        // Get score from ScoreInGame
        scoreLast = ScoreInGame.score;

        // save score to memory and compare with last score
        if (scoreLast > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", scoreLast);
            //Debug.Log("Najlepszy wynik: " + scoreLast);
            highscoreSound.Play();
        }
        else
        {
            looseSound.Play();
        }

        // Score from last play in GameOverPage
        lastGameScore.text = "Your Score: " + scoreLast;
        // Best High Score in GameOverPage
        highscoreBestText.text = "High Score:" + PlayerPrefs.GetInt("Highscore", 0).ToString();
        // Best High Score in StartPage
        highscoreStartText.text = highscoreBestText.text;


    }
}
