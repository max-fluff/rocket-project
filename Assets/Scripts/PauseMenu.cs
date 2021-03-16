using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private static bool _isPaused=false;
    public GameObject pauseMenuUI;
    void Update()
    {
        if (!Input.GetButtonDown("Cancel")) return;
        if (_isPaused)
            Resume();
        else
            Pause();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
    }
}
