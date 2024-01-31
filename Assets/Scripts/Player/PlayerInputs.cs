using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    /// <summary>
    /// Player input component of the player.
    /// </summary>
    private PlayerInput _playerInput;

    /// <summary>
    /// Player movements component of the player.
    /// </summary>
    private PlayerMovements _playerMovements;

    /// <summary>
    /// A value indicating if it's the first input.
    /// </summary>
    private bool _itsFirstInput;

    /// <summary>
    /// Generator of pipes.
    /// </summary>
    [SerializeField]
    private PipeGenerator _pipeGenerator;

    /// <summary>
    /// Score on screen.
    /// </summary>
    [SerializeField]
    private GameObject _scoreUI;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerMovements = GetComponent<PlayerMovements>();
        _itsFirstInput = true;

        _playerInput.onActionTriggered += OnAction;
    }

    /// <summary>
    /// Called when an input is pressed.
    /// </summary>
    /// <param name="context"> Informations about the input. </param>
    private void OnAction(InputAction.CallbackContext context)
    {
        if (!GameManager.Instance.GameIsPaused && !GameManager.Instance.GameIsOver)
        {
            if (_itsFirstInput && context.action.name == "Fly")
            {
                _itsFirstInput = false;
                _playerMovements.FirstInput();
                _pipeGenerator.StartGeneration();
                UIManager.Instance.ShowScore();

                if (!MusicManager.Instance.HasAlreadyBeenLaunched)
                {
                    MusicManager.Instance.LaunchGameMusic();
                }
            }

            switch (context.action.name)
            {
                case "Fly":
                    if (context.started)
                    {
                        _playerMovements.Fly();
                    }
                    break;
                case "Pause":
                    if (context.started)
                    {
                        GameManager.Instance.GamePause();
                    }
                    break;
            }
        }
    }
}
