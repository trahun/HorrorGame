using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private PlayerInputHandler _input;
    private GroundChecker _groundChecker;
    private PlayerMovement _mover;
    private MovementStateMachine _stateMachine = new();

    private void Awake()
    {
        _input = GetComponent<PlayerInputHandler>();
        _groundChecker = GetComponent<GroundChecker>();
        _mover = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        bool isGrounded = _groundChecker.IsGrounded();
        _stateMachine.UpdateState(isGrounded, _input.IsRunning);
    }

    void FixedUpdate()
    {
        _mover.Move(_input.Horizontal, _input.Vertical);
    }
}
