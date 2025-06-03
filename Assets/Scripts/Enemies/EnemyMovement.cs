using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.5f;
    private Vector2 _moveDirection;
    private Rigidbody2D _rigidBody;
    private KnockBack _knockBack;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _knockBack = GetComponent<KnockBack>();
    }

    private void FixedUpdate()
    {
        if (_knockBack.IsGettingKnockBack)
        {
            return;
        }

        _rigidBody.MovePosition(_rigidBody.position + _moveDirection * (_moveSpeed * Time.fixedDeltaTime));
    }

    public void SetMoveDirection(Vector2 moveDirection)
    {
        _moveDirection = moveDirection;
    }
}
