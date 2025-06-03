using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _healthPoint = 10;
    [SerializeField] private float _knockBackForce = 10f;
    private KnockBack _knockBack;

    private void Awake()
    {
        _knockBack = GetComponent<KnockBack>();
    }

    public void TakeDamage(int damage)
    {
        _healthPoint = Mathf.Clamp(_healthPoint - damage, 0, _healthPoint);
        _knockBack.GetKnockback(PlayerController.Instance.transform, _knockBackForce);
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (_healthPoint > 0)
        {
            return;
        }

        Destroy(this.gameObject);
    }
}
