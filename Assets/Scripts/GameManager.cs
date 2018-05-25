using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject startPage;
    public GameObject countdownPage;
    public GameObject gamePage;
    public GameObject gameOverPage;

    public AudioSource playSound;
    public AudioSource replySound;    

    public bool gameOver = false;

    enum PageState
    {
        Start,
        Countdown,
        GamePage,
        GameOver
    }
    
    public bool GameOver { get { return GameOver; } }
    
    private void OnEnable()
    {
        CountdownText.OnCountdownFinished += OnCountdownFinished;
        TimerInGame.OnTimeOver += OnTimeOver;
    }

    private void OnDisable()
    {
        CountdownText.OnCountdownFinished -= OnCountdownFinished;
        TimerInGame.OnTimeOver -= OnTimeOver;
    }

    void SetPageState(PageState state)
    {
        switch (state)
        {
            case PageState.Start:
                startPage.SetActive(true);      //aktywny canvas
                countdownPage.SetActive(false);
                gamePage.SetActive(false);
                gameOverPage.SetActive(false);
                break;

            case PageState.Countdown:
                startPage.SetActive(false);
                countdownPage.SetActive(true);  //aktywny canvas
                gamePage.SetActive(false);
                gameOverPage.SetActive(false);
                break;

            case PageState.GamePage:
                startPage.SetActive(false);
                countdownPage.SetActive(false);
                gamePage.SetActive(true);       //aktywny canvas
                gameOverPage.SetActive(false);
                break;

            case PageState.GameOver:
                startPage.SetActive(false);
                countdownPage.SetActive(false);
                gamePage.SetActive(false);
                gameOverPage.SetActive(true);   //aktywny canvas
                break;

        }
    }
    void Start()
    {
        // Start Page and High score reset 
        SetPageState(PageState.Start);
        PlayerPrefs.DeleteAll();

    }

    public void StartGame()
    {
        // show CountdownPage after Play Button and play sound
        SetPageState(PageState.Countdown);
        playSound.Play();
    }

    public void OnCountdownFinished()
    {
        // show GamePage after 3..2..1.. countdown
        SetPageState(PageState.GamePage);
        gameOver = false;
    }

    // show GameOver Page after 10 sec
    public void OnTimeOver()
    {
        gameOver = true;
        SetPageState(PageState.GameOver);
    }

    public void ConfirmGameOver()
    {
        // show Start Page after reply button
        SetPageState(PageState.Start);
        replySound.Play();
    }

    // Update is called once per frame
    void Update()
    {
    }


}
