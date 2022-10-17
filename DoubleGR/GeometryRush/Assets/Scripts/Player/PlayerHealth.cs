using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    private float _maxValue = 100f;
    private float _minValue = 0f;
    private float _currentValue;
    private float _valueToChangeHealth = 10f;

    public float MaxValue => _maxValue;

    public event UnityAction<float> HealthChanged;

    private void Start()
    {
        _currentValue = _maxValue;
    }

    public void Heal()
    {
        if (_currentValue <= _maxValue)
        {
            _currentValue = Mathf.Clamp(_currentValue += _valueToChangeHealth, _minValue, _maxValue);
            HealthChanged?.Invoke(_currentValue);
        }
    }

    public void TakeDamage()
    {
        if (_currentValue > _minValue)
        {
            _currentValue = Mathf.Clamp(_currentValue -= _valueToChangeHealth, _minValue, _maxValue);
            HealthChanged?.Invoke(_currentValue);
        }
    }
}
