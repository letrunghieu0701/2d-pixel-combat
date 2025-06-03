using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private float _moveSpeed = 1f;

    private PlayerControllers _playerControllers;
    private Vector2 _movementInput;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private bool _isFacingLeft;
    public bool IsFacingLeft
    {
        get { return _isFacingLeft; }
    }
    private void Awake()
    {
        Instance = this;
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

        _animator.SetFloat("MoveX", _movementInput.x);
        _animator.SetFloat("MoveY", _movementInput.y);
    }

    private void Move()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movementInput * (_moveSpeed * Time.deltaTime));
    }

    private void AdjustFacingDirection()
    {
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(_rigidbody.position);
        _isFacingLeft = Input.mousePosition.x < playerScreenPoint.x;
        _spriteRenderer.flipX = _isFacingLeft;
    }
}
