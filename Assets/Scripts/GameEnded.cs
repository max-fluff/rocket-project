using UnityEngine;

public class GameEnded : MonoBehaviour
{
    [SerializeField] private SceneManagement sceneManager;
    void GE()
    {
        sceneManager.MainMenu();
    }
}
