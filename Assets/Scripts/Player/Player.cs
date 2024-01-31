using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Score component.
    /// </summary>
    [SerializeField]
    private Score _score;

    private void OnTriggerEnter(Collider other)
    {
        // Ckecks which object player hits
        switch (other.tag)
        {
            case "Pipe":
                {
                    GameManager.Instance.GameOver();
                    break;
                }
            case "Passage":
                {
                    _score.AddScore();
                    break;
                }
            case "Void":
                {
                    GameManager.Instance.GameOver();
                    break;
                }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Destroy the player if he falls under the screen
        switch (other.tag)
        {
            case "Void":
                {
                    Destroy(gameObject);
                    break;
                }
        }
    }
}
