using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;

    private PlayerControllers _playerControllers;
    private Vector2 _movementInput;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _playerControllers = new PlayerControllers();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        ReadPlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnEnable()
    {
        _playerControllers.Enable();
    }

    private void ReadPlayerInput()
    {
        _movementInput = _playerControllers.Movement.Move.ReadValue<Vector2>();
        Debug.Log(_movementInput.x + " " + _movementInput.y);
    }

    private void Move()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movementInput * (_moveSpeed * Time.deltaTime));
    }
}
