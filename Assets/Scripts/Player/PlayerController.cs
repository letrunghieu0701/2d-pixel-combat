using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private float _moveSpeed = 1;
    private float _defaultMoveSpeed;

    [SerializeField] private float _dashSpeed = 2;
    [SerializeField] private float _dashTime = 0.2f;
    [SerializeField] private float _dashCoolDownTime = 2;
    private bool _canDash = true;

    private PlayerControllers _playerControllers;
    private Vector2 _movementInput;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private TrailRenderer _trailrenderer;

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
        _trailrenderer = transform.Find("TrailDash").GetComponent<TrailRenderer>();
        _trailrenderer.emitting = false;
        _defaultMoveSpeed = _moveSpeed;
    }

    private void Start()
    {
        _playerControllers.Combat.Dash.performed += _ => Dash();
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

    private void Dash()
    {
        if (!_canDash)
        {
            return;
        }

        _canDash = false;
        _moveSpeed = _dashSpeed;
        _trailrenderer.emitting = true;
        StartCoroutine(EndDashRoutine());
    }

    private IEnumerator EndDashRoutine()
    {
        yield return new WaitForSeconds(_dashTime);
        _moveSpeed = _defaultMoveSpeed;
        _trailrenderer.emitting = false;

        yield return new WaitForSeconds(_dashCoolDownTime);
        _canDash = true;
    }
}
