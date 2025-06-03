using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _healthPoint = 10;

    public void TakeDamage(int damage)
    {
        _healthPoint = Mathf.Clamp(_healthPoint - damage, 0, _healthPoint);
        Debug.Log(_healthPoint);
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
