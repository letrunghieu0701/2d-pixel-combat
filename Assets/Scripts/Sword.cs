using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private PlayerControllers _playerControllers;
    private Animator _animator;
    private PlayerController _playerController;
    private ActiveWeapon _activeWeapon;

    private void Awake()
    {
        _playerControllers = new PlayerControllers();
        _animator = GetComponent<Animator>();
        _playerController = GetComponentInParent<PlayerController>();
        _activeWeapon = GetComponentInParent<ActiveWeapon>();
    }

    private void Start()
    {
        _playerControllers.Combat.Attack.started += _ => Attack();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        AdjustFacingDirection();
    }

    private void OnEnable()
    {
        _playerControllers.Enable();
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
    }

    private void AdjustFacingDirection()
    {

        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(_playerController.transform.position);
        bool isFlipLeftSide = Input.mousePosition.x < playerScreenPoint.x;
        if (isFlipLeftSide)
        {
            _activeWeapon.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            _activeWeapon.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
