using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;

    private PlayerControllers _playerControllers;
    private Vector2 _movementInput;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _playerControllers = new PlayerControllers();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
        AdjustFacingDirection();
        Move();
    }

    private void OnEnable()
    {
        _playerControllers.Enable();
    }

    private void ReadPlayerInput()
    {
        _movementInput = _playerControllers.Movement.Move.ReadValue<Vector2>();

        _animator.SetFloat("moveX", _movementInput.x);
        _animator.SetFloat("moveY", _movementInput.y);
    }

    private void Move()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movementInput * (_moveSpeed * Time.deltaTime));
    }

    private void AdjustFacingDirection()
    {
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(_rigidbody.position);
        bool isFlipLeftSide = Input.mousePosition.x < playerScreenPoint.x;
        _spriteRenderer.flipX = isFlipLeftSide;
    }
}
