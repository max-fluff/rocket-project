using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnded : MonoBehaviour
{
    public SceneManagement sceneManager;
    void GE()
    {
        sceneManager.MainMenu();
    }
}
