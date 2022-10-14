using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldSpawner : MonoBehaviour
{
    [SerializeField] private MoneyCounter _moneyCounter;
    [SerializeField] private Shield _shield;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private TMP_Text _shieldCostDisplay;

    private int _currentPointCount;
    private int _shieldCost;
    private int _increaseOfShieldCost = 20;
    private string _costTxt = "$ ";

    private void Start()
    {
        _shieldCost = _increaseOfShieldCost;
        _shieldCostDisplay.text = _costTxt + _shieldCost.ToString();
        _currentPointCount = 0;
    }

    public void Spawn()
    {
        if (_moneyCounter.Money >= _shieldCost)
        {
            if (_currentPointCount < _spawnPoints.Count)
            {
                Instantiate(_shield, _spawnPoints[_currentPointCount].position, Quaternion.identity);
                _currentPointCount++;
                _moneyCounter.SpendMoney(_shieldCost);
                _shieldCost += _increaseOfShieldCost;
                _shieldCostDisplay.text = _costTxt + _shieldCost.ToString();
            }
        }
    }
}
