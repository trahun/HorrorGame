using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private float _speed;
    public float _walkSpeed;
    public float _runSpeed;

    public float _groundDrag;
    [Header("GroundCheck")]
    public float _playerHeight;
    public LayerMask _groundLayer;
    bool _isGrounded;

    public Transform _orientation;
    float _horizontal;
    float _vertical;
    Vector3 _MoveDirection;
    Rigidbody _rigidbody;

    [Header("KeyBindings")] public KeyCode JumpKey = KeyCode.Space;
    public KeyCode RunKey = KeyCode.LeftShift;

    public MovementState state;

    public enum MovementState
    {
        walking,
        running,
        air
    }



    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }

    void Update()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight * 0.5f + 0.2f, _groundLayer);
        MyInput();
        StateHandler();

        if (_isGrounded)
        {
            _rigidbody.linearDamping = _groundDrag;
        }
    }

private void FixedUpdate()
    {
        MovePlayer();
    }

    
    
    //изменение скорости во время спринта/ходьбы
    private void StateHandler()
    {
        if (Input.GetKey(RunKey))
        {
            state = MovementState.running;
            _speed = _runSpeed;
        }
        else
        {
            state = MovementState.walking;
            _speed = _walkSpeed;
        }
    }

    
    
    //считывание с клавиатуры
    private void MyInput()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }
    
    
    
    //передвижение
    private void MovePlayer()
    {
        _MoveDirection = _orientation.forward * _vertical + _orientation.right * _horizontal;
        _rigidbody.MovePosition(_rigidbody.position + _MoveDirection.normalized * _speed * Time.deltaTime);
    }
}
