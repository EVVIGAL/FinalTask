using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerDestroyer _health;
    [SerializeField] private Slider _slider;

    private Coroutine _valueController;
    private float _scrollSpeed = 0.4f;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _health.HealthChanged += RestartCoroutine;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= RestartCoroutine;
    }

    private IEnumerator ChangeValue(float target)
    {
        target /= _health.MaxValue;

        while (_slider.value >= 0 && _slider.value <= 1)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _scrollSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void RestartCoroutine(float target)
    {
        if (_valueController != null)
            StopCoroutine(_valueController);

        _valueController = StartCoroutine(ChangeValue(target));
    }
}
