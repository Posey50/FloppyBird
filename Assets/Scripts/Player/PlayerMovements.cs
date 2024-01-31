using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    /// <summary>
    /// Value of the impulse given to the player to fly.
    /// </summary>
    [field: SerializeField]
    private float _impulse;

    /// <summary>
    /// Rigidbody component of the player.
    /// </summary>
    private Rigidbody _rb;

    /// <summary>
    /// Animator component of the player.
    /// </summary>
    private Animator _animator;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    /// <summary>
    /// Called to give an impulse to the player.
    /// </summary>
    public void Fly()
    {
        _rb.velocity = Vector3.zero;
        _rb.AddForce(new Vector3(0f, _impulse, 0f));
        _animator.SetTrigger("Fly");
    }

    /// <summary>
    /// Called if it's the first input.
    /// </summary>
    public void FirstInput()
    {
        _rb.constraints = RigidbodyConstraints.None;
        _rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX |
                          RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }
}
