using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager _instance = null;
    public static GameManager Instance => _instance;

    /// <summary>
    /// Gets or sets a value indicating if the game is over.
    /// </summary>
    public bool GameIsOver {  get; set; }

    /// <summary>
    /// Gets or sets a value indicating if the game is paused.
    /// </summary>
    public bool GameIsPaused { get; set; }

    /// <summary>
    /// Pipe generator.
    /// </summary>
    [SerializeField]
    private PipeGenerator _pipeGenerator;

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

    /// <summary>
    /// Called to stop the game.
    /// </summary>
    public void GameOver()
    {
        GameIsOver = true;
        _pipeGenerator.StopGeneration();
        UIManager.Instance.GameOver();
    }

    /// <summary>
    /// Called to pause the game.
    /// </summary>
    public void GamePause()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;
        UIManager.Instance.Pause();
    }
}