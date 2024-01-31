using UnityEngine;

public class Pipe : MonoBehaviour
{
    /// <summary>
    /// Speed of a pipe.
    /// </summary>
    [SerializeField]
    private float _speed;

    private void OnTriggerEnter(Collider other)
    {
        // Destroys the pipe if it is outside of the screen
        if (other.CompareTag("EndOfPipes"))
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.GameIsOver && !GameManager.Instance.GameIsPaused)
        {
            // Makes moving the pipe
            transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);
        }
    }
}
