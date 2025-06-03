using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashWhiteEffect : MonoBehaviour
{
    [SerializeField] private float _flashTime = 0.1f;
    [SerializeField] private Material _flashWhiteMaterial;
    private Material _defaultMaterial;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultMaterial = _spriteRenderer.material;
    }

    public IEnumerator FlashRoutine()
    {
        _spriteRenderer.material = _flashWhiteMaterial;
        yield return new WaitForSeconds(_flashTime);
        _spriteRenderer.material = _defaultMaterial;
    }

    public float GetFlashTime()
    {
        return _flashTime;
    }
}
