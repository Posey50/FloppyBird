using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    /// <summary>
    /// Score of the player.
    /// </summary>
    private int _score;

    /// <summary>
    /// Score showed at screen.
    /// </summary>
    private TMP_Text _scoreUI;

    private void Start()
    {
        _scoreUI = GetComponent<TMP_Text>();
    }

    /// <summary>
    /// Increases score.
    /// </summary>
    public void AddScore()
    {
        _score += 1;
        UpdateUI();
    }

    /// <summary>
    /// Called to update the score at screen.
    /// </summary>
    private void UpdateUI()
    {
        _scoreUI.text = _score.ToString();
    }
}
