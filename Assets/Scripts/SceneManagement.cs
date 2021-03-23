using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject fin;
    public PauseMenu pauseMenu;
    public void LevelPassed()
    {
         fin.SetActive(true);
    }
    public void SceneRestart()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        LoadScene(0); 
    }

    private void LoadScene(int buildIndex)
    {
        Time.timeScale = 1f;
        if(pauseMenu!=null) pauseMenu.Resume();
        SceneManager.LoadScene(buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
