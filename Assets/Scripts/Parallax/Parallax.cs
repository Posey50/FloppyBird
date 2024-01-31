using UnityEngine;

public class Parallax : MonoBehaviour
{
    /// <summary>
    /// Scroll speed of the layer.
    /// </summary>
    [field: SerializeField]
    private float _scrollSpeed;

    /// <summary>
    /// Start position of the sprite layer.
    /// </summary>
    private Vector2 _startPos;

    /// <summary>
    /// Sprite renderer component of the layer.
    /// </summary>
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _startPos = transform.position;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.GameIsOver && !GameManager.Instance.GameIsPaused)
        {
            transform.position = new Vector2(transform.position.x - _scrollSpeed * Time.deltaTime, transform.position.y);

            // If the current position is equal to the start position + the size of the sprite, then it comes back to the start position
            if (transform.position.x < -_spriteRenderer.bounds.size.x)
            {
                transform.position = _startPos;
            }
        }
    }
}
