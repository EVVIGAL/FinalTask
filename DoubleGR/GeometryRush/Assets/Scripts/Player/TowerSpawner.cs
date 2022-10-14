using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private MoneyCounter _moneyCounter;
    [SerializeField] private GameObject _tower;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private TMP_Text _costDisplay;

    private int _maxTowers = 4;
    private int _currentTower;
    private string _costTxt = "$ ";
    private int _towerCost;
    private int _increaseOfTowerCost = 30;

    private void Start()
    {
        _currentTower = 0;
        _towerCost = _increaseOfTowerCost;
        _costDisplay.text = _costTxt + _towerCost.ToString();
    }

    public void Spawn()
    {
        if (_moneyCounter.Money >= _towerCost)
        {
            if (_currentTower < _maxTowers)
            {
                Instantiate(_tower, _spawnPoints[_currentTower].transform.position, Quaternion.identity);
                _currentTower++;
                _moneyCounter.SpendMoney(_towerCost);
                _towerCost += _increaseOfTowerCost;
                _costDisplay.text = _costTxt + _towerCost.ToString();
            }
        }
    }
}
