using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum EnemyState
    {
        Roaming,
    }

    private EnemyState _state;
    private EnemyMovement _movement;

    [SerializeField] private float _changeRoamDirectionInterval = 2f;

    private void Awake()
    {
        _state = EnemyState.Roaming;
        _movement = GetComponent<EnemyMovement>();
    }

    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }

    private IEnumerator RoamingRoutine()
    {
        while (_state == EnemyState.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            _movement.SetMoveDirection(roamPosition);
            yield return new WaitForSeconds(_changeRoamDirectionInterval);
        }
    }

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }
}
