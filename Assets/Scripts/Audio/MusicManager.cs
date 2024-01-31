using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Singleton
    private static MusicManager _instance = null;
    public static MusicManager Instance => _instance;

    /// <summary>
    /// A value indicating that the music has already been launched.
    /// </summary>
    public bool HasAlreadyBeenLaunched { get; private set; }

    /// <summary>
    /// Music to launch when the game starts.
    /// </summary>
    [SerializeField]
    private AudioClip _inGameMusic;

    /// <summary>
    /// Audio source component.
    /// </summary>
    private AudioSource _audioSource;

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

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Called to launch the music when the game starts.
    /// </summary>
    public void LaunchGameMusic()
    {
        HasAlreadyBeenLaunched = true;
        _audioSource.clip = _inGameMusic;
        _audioSource.Play();
    }
}
