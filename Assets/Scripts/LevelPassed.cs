using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPassed : MonoBehaviour
{
    public SceneManagement sceneManager;
    void LP()
    {
        sceneManager.NextScene();
    }
}
