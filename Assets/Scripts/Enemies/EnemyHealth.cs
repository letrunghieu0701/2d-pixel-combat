using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _healthPoint = 10;
    [SerializeField] private float _knockBackForce = 10f;
    private KnockBack _knockBack;
    private FlashWhiteEffect _flashWhiteEffect;

    [SerializeField] private GameObject _deathVFX;

    private void Awake()
    {
        _knockBack = GetComponent<KnockBack>();
        _flashWhiteEffect = GetComponent<FlashWhiteEffect>();
    }

    public void TakeDamage(int damage)
    {
        if (_healthPoint == 0)
        {
            return;
        }

        _healthPoint = Mathf.Clamp(_healthPoint - damage, 0, _healthPoint);
        StartCoroutine(_flashWhiteEffect.FlashRoutine());
        _knockBack.GetKnockback(PlayerController.Instance.transform, _knockBackForce);
        StartCoroutine(CheckDetectDeathRoutine());
    }

    private IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(_flashWhiteEffect.GetFlashTime());
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (_healthPoint > 0)
        {
            return;
        }

        Instantiate(_deathVFX, transform.position, Quaternion.identity); // To-do: add object pooling
        Destroy(this.gameObject);
    }
}
