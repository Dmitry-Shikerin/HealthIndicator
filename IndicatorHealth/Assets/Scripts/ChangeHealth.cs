using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHealth : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private float _targetValue;
    private float _maxDelta;
    private float _iterationCount;
    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds;
    private float _delay;

    private void Start()
    {
        _maxDelta = 0.01f;
        _iterationCount = 10;
        _delay = 0.1f;
        _waitForSeconds = new WaitForSeconds(_delay);
    }

    public void Activate(float targetValue)
    {
        StopCoroutine();
        _coroutine = StartCoroutine(ChangedHealth(targetValue));
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
        _targetValue = _slider.value + targetValue;

        for (int i = 0; i < _iterationCount; i++)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _maxDelta);

            yield return _waitForSeconds;
        }
    }
}
