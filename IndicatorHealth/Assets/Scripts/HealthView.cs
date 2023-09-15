using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;

    private float _targetValue;
    private float _maxDelta;
    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds;
    private float _delay;

    private void Start()
    {
        _maxDelta = 0.01f;
        _delay = 0.1f;
        _waitForSeconds = new WaitForSeconds(_delay);
        _slider.maxValue = _health.Max;
    }

    private void OnEnable()
    {
        _health.Changed += Activate;
    }

    private void OnDisable()
    {
        _health.Changed -= Activate;
    }

    public void Activate()
    {
        StopCoroutine();
        _coroutine = StartCoroutine(ChangedHealth(_health.Current));
    }

    private void StopCoroutine()
    {
        if (_coroutine == null)
        {
            return;
        }

        StopCoroutine(_coroutine);
    }

    private IEnumerator ChangedHealth(float targetValue)
    {
        _targetValue = targetValue;

        while (Mathf.Abs(_slider.value - targetValue) > Mathf.Epsilon)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _maxDelta);

            yield return _waitForSeconds;
        }

        _slider.value = targetValue;
    }
}
