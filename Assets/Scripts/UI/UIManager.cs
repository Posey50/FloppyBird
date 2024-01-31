using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Singleton
    private static UIManager _instance = null;
    public static UIManager Instance => _instance;

    /// <summary>
    /// Score showed at screen.
    /// </summary>
    [SerializeField]
    private GameObject _score;

    /// <summary>
    /// Button to pause the game.
    /// </summary>
    [SerializeField]
    private GameObject _pauseButton;

    /// <summary>
    /// Screen showed at the game pause.
    /// </summary>
    [SerializeField]
    private GameObject _pauseScreen;

    /// <summary>
    /// Animator component of the canva.
    /// </summary>
    private Animator _animator;

    private void Awake()
    {
        // Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Called to show the score.
    /// </summary>
    public void ShowScore()
    {
        _score.SetActive(true);
    }
    
    /// <summary>
    /// Called to set up the pause screen.
    /// </summary>
    public void Pause()
    {
        _pauseButton.SetActive(false);
        _pauseScreen.SetActive(true);
    }

    /// <summary>
    /// Called to resume the game screen.
    /// </summary>
    public void Resume()
    {
        GameManager.Instance.GameIsPaused = false;
        Time.timeScale = 1.0f;
        _pauseScreen.SetActive(false);
        _pauseButton.SetActive(true);
    }

    /// <summary>
    /// Called to set up the end screen.
    /// </summary>
    public void GameOver()
    {
        _pauseButton.SetActive(false);
        _animator.SetBool("GameIsOver", true);
    }

    /// <summary>
    /// Called to restart the game.
    /// </summary>
    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Called to quit the game.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
