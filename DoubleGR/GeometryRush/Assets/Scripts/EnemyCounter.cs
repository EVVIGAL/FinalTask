using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private List<Spawner> _enemySpawners;
    [SerializeField] private MoneyCounter _moneyCounter;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _lvlText;
    [SerializeField] private int _needToUpgradeEnemy;
    [SerializeField] private int _IncreseOfNeedToUpgradeEnemy;

    private int _enemyDestroyed = 0;
    private int _lvl = 1;
    private int _score = 0;
    private string _scoreTxt = "Score: ";
    private string _lvlTxt = ": Level";

    public int Score => _score;

    private void OnEnable()
    {
        foreach(Spawner spawner in _enemySpawners)
            spawner.isSpawned += SetEnemy;

        _scoreText.text = _scoreTxt + _score.ToString();
        _lvlText.text = _lvl.ToString() + _lvlTxt;
    }

    private void OnDisable()
    {
        foreach (Spawner spawner in _enemySpawners)
            spawner.isSpawned -= SetEnemy;
    }

    private void Update()
    {
        EnemyLevelUp();
    }

    private void SetEnemy(GameObject enemy)
    {
        if (enemy.TryGetComponent(out Enemy enemy1))
        {
            enemy1.isInactive += DestroyCounter;
        }
    }

    private void DestroyCounter(GameObject enemy, int value)
    {
        _enemyDestroyed++;
        _score += value;
        _moneyCounter.AddMoney(value);
        _scoreText.text = _scoreTxt + _score.ToString();

        if (enemy.TryGetComponent(out Enemy enemy1))
        {
            enemy1.isInactive -= DestroyCounter;
        }
    }

    private void EnemyLevelUp()
    {
        if (_enemyDestroyed >= _needToUpgradeEnemy)
        {
            foreach (Spawner spawner in _enemySpawners)
                spawner.LevelUp();

            _lvl++;
            _lvlText.text = _lvl.ToString() + _lvlTxt;
            _enemyDestroyed = 0;
            _needToUpgradeEnemy += _IncreseOfNeedToUpgradeEnemy;
        }
    }
}
