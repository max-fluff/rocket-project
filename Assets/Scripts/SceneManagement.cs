using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private GameObject fin;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button nextSceneButton;
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


    private void Awake()
    {
        if(quitButton!=null) quitButton.onClick.AddListener(QuitGame);
        if(restartButton!=null) restartButton.onClick.AddListener(SceneRestart);
        if(mainMenuButton!=null) mainMenuButton.onClick.AddListener(MainMenu);
        if(nextSceneButton!=null)nextSceneButton.onClick.AddListener(NextScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
