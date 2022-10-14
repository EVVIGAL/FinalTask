using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(CircleCollider2D))]

public class PlayerDestroyer : MonoBehaviour
{
    [SerializeField] private MoneyCounter _moneyCounter;
    [SerializeField] private GameObject _particles;
    [SerializeField] private GameObject panel;
    [SerializeField] private Menu _menu;
    [SerializeField] private TMP_Text _healthDisplay;
    [SerializeField] private TMP_Text _healCostDisplay;
    [SerializeField] private TMP_Text _maxHPUpCostDisplay;
    [SerializeField] private TextMeshProUGUI _gameOverTxt;
    [SerializeField] private float _maxHealth;

    public event UnityAction<float> HealthChanged;

    private float _currentHealth;
    private float _healthUpgrade = 1f;
    private float _minHealth = 0;
    private string _maxHPTxt = "Max HP:\n";
    private int _maxHPUpCost;
    private int _IncreaseOfMaxHPUp = 10;
    private int _healCost;
    private int _increaseOfHealCost = 5;
    private string _costTxt = "$ ";

    public float MaxValue => _maxHealth;

    private void Start()
    {
        _healCost = _increaseOfHealCost;
        _healCostDisplay.text = _costTxt + _healCost.ToString();
        _maxHPUpCost = _IncreaseOfMaxHPUp;
        _maxHPUpCostDisplay.text = _costTxt + _maxHPUpCost.ToString();
        _healthDisplay.text = _maxHPTxt + _maxHealth.ToString();
        _currentHealth = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            TakeDamage(enemy.DealDamage());
        }

        if (collision.TryGetComponent(out EnemyBullet enemyBullet))
        {
            TakeDamage(enemyBullet.DealDamage());
        }
    }

    void Update()
    {
        Deactivate();
    }

    public void UpgradeMaxHealth()
    {
        if (_moneyCounter.Money >= _maxHPUpCost)
        {
            _maxHealth += _healthUpgrade;
            _healthDisplay.text = _maxHPTxt + _maxHealth.ToString();

            if (_currentHealth != _maxHealth)
                _currentHealth = _maxHealth;

            HealthChanged?.Invoke(_currentHealth);
            _moneyCounter.SpendMoney(_maxHPUpCost);
            _maxHPUpCost += _IncreaseOfMaxHPUp;
            _maxHPUpCostDisplay.text = _costTxt + _maxHPUpCost.ToString();
        }
    }

    public void Heal()
    {
        if (_moneyCounter.Money >= _healCost)
        {
            _currentHealth = _maxHealth;
            HealthChanged?.Invoke(_currentHealth);
            _moneyCounter.SpendMoney(_healCost);
            _healCost += _increaseOfHealCost;
            _healCostDisplay.text = _costTxt + _healCost.ToString();
        }
    }

    public void TakeDamage(float _valueToChangeHealth)
    {
        if (_currentHealth > _minHealth)
        {
            _currentHealth = Mathf.Clamp(_currentHealth -= _valueToChangeHealth, _minHealth, _maxHealth);
            HealthChanged?.Invoke(_currentHealth);
        }
    }

    private void Deactivate()
    {
        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
            Instantiate(_particles, transform.position, Quaternion.identity);
            _currentHealth = _maxHealth;
            _gameOverTxt.enabled = true;
            _menu.Open(panel);
        }
    }
}
