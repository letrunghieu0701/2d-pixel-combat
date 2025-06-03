using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private PlayerControllers _playerControllers;
    private Animator _animator;
    private PlayerController _playerController;
    private ActiveWeapon _activeWeapon;

    private GameObject _slashEffectGo;
    private SpriteRenderer _slashEffectRenderer;

    private GameObject _damageCollider;

    private void Awake()
    {
        _playerControllers = new PlayerControllers();
        _animator = GetComponent<Animator>();
        _playerController = GetComponentInParent<PlayerController>();
        _activeWeapon = GetComponentInParent<ActiveWeapon>();

        _slashEffectGo = transform.parent.Find("SlashEffect").gameObject;
        _slashEffectGo.SetActive(false);
        _slashEffectRenderer = _slashEffectGo.GetComponent<SpriteRenderer>();

        _damageCollider = transform.parent.Find("DamageCollider").gameObject;
        _damageCollider.SetActive(false);
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
        _damageCollider.SetActive(true);
    }

    private void AdjustFacingDirection()
    {
        if (_playerController.IsFacingLeft)
        {
            _activeWeapon.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            _activeWeapon.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void SlashDownAnimEvent()
    {
        _slashEffectRenderer.flipY = false;
        _slashEffectGo.SetActive(true);
    }

    public void SlashUpAnimEvent()
    {
        _slashEffectRenderer.flipY = true;
        _slashEffectGo.SetActive(true);
    }

    public void FinishAttackingAnimEvent()
    {
        _damageCollider.SetActive(false);
    }
}
