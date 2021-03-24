using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private static bool _isPaused;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private Button resumeButton;
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
        if (!_isPaused) return;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;
    }

    public void Pause()
    {
        if (_isPaused) return;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
    }
    private void Awake()
    {
        resumeButton.onClick.AddListener(Resume);
    }
}
