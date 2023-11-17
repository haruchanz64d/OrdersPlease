using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public Canvas gameplayCanvas;
    public Canvas pauseCanvas;

    public Canvas gameOverCanvas;
    public Canvas gameSuccessCanvas;

    private void Awake()
    {
        OnGameplayResume();
    }

    public void OnGameplayPause()
    {
        Time.timeScale = 0f;
        gameplayCanvas.enabled = true;
        pauseCanvas.enabled = true;
        gameOverCanvas.enabled = false;
        gameSuccessCanvas.enabled = false;
    }

    public void OnGameplayResume()
    {
        Time.timeScale = 1f;
        gameplayCanvas.enabled = true;
        pauseCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        gameSuccessCanvas.enabled = false;
    }

    public void OnGameOver(){
        Time.timeScale = 0f;
        gameplayCanvas.enabled = true;
        pauseCanvas.enabled = false;
        gameOverCanvas.enabled = true;
        gameSuccessCanvas.enabled = false;
    }

    public void OnGameSuccess()
    {
        Time.timeScale = 0f;
        gameplayCanvas.enabled = true;
        pauseCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        gameSuccessCanvas.enabled = true;
    }
}
