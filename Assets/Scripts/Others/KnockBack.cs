using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public bool IsGettingKnockBack { get; private set; }
    [SerializeField] [Range(0, 10)] private float _knockBackTime = 0.2f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        IsGettingKnockBack = false;
    }

    public void GetKnockback(Transform knockbackSource, float knockBackForce)
    {
        IsGettingKnockBack = true;
        Vector2 knockVector = (transform.position - knockbackSource.position).normalized * (knockBackForce * _rigidBody.mass);
        _rigidBody.AddForce(knockVector, ForceMode2D.Impulse);
        StartCoroutine(KnockBackRoutine());
    }

    private IEnumerator KnockBackRoutine()
    {
        yield return new WaitForSeconds(_knockBackTime);
        _rigidBody.velocity = Vector2.zero;
        IsGettingKnockBack = false;
    }
}
