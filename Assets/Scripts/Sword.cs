using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private PlayerControllers _playerController;
    private Animator _animator;

    private void Awake()
    {
        _playerController = new PlayerControllers();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _playerController.Combat.Attack.started += _ => Attack();
    }

    private void OnEnable()
    {
        _playerController.Enable();
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
    }
}
