using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public Canvas gameplayCanvas;
    public Canvas pauseCanvas;

    public Canvas gameOverCanvas;
    public Canvas gameSuccessCanvas;

    public AudioSource gameplayBGM;
    public AudioSource victoryBGM;
    public AudioSource gameoverBGM;


    private void Awake()
    {
        OnGameplayResume();
    }

    public void OnGameplayPause()
    {
        Time.timeScale = 0f;
        gameplayBGM.Stop();
        gameplayCanvas.enabled = true;
        pauseCanvas.enabled = true;
        gameOverCanvas.enabled = false;
        gameSuccessCanvas.enabled = false;
    }

    public void OnGameplayResume()
    {
        Time.timeScale = 1f;
        gameplayBGM.Stop();
        gameplayBGM.PlayDelayed(1.5f);
        gameplayCanvas.enabled = true;
        pauseCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        gameSuccessCanvas.enabled = false;
    }

    public void OnGameOver()
    {
        Time.timeScale = 0f;
        gameplayBGM.Stop();
        gameoverBGM.PlayDelayed(1.5f);
        gameplayCanvas.enabled = true;
        pauseCanvas.enabled = false;
        gameOverCanvas.enabled = true;
        gameSuccessCanvas.enabled = false;
    }

    public void OnGameSuccess()
    {
        Time.timeScale = 0f;
        victoryBGM.PlayDelayed(1.5f);
        gameplayCanvas.enabled = true;
        pauseCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        gameSuccessCanvas.enabled = true;
    }
}
