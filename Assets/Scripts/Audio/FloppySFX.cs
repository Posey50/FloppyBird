using UnityEngine;
using System.Collections.Generic;

public class FloppySFX : MonoBehaviour
{
    /// <summary>
    /// List of SFX to launch at each flapping of wings.
    /// </summary>
    [SerializeField]
    private List<AudioClip> _flapps;

    /// <summary>
    /// Audio source component.
    /// </summary>
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Called to play a flapping SFX.
    /// </summary>
    public void Flap()
    {
        _audioSource.clip = _flapps[Random.Range(0, _flapps.Count)];
        _audioSource.Play();
    }
}
