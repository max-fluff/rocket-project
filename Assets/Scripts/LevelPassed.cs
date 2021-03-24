using UnityEngine;

public class LevelPassed : MonoBehaviour
{
    [SerializeField] private SceneManagement sceneManager;
    void LP()
    {
        sceneManager.NextScene();
    }
}
