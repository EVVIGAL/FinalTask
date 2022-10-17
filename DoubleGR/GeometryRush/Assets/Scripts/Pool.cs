using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pool : MonoBehaviour
{
    [SerializeField] protected Player _player;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    protected List<GameObject> _pool = new();
    protected float _damageIncrease;
    protected float _healthIncrease;
    protected float _speedIncrease;

    public Player Player => _player;

    public void LevelUp()
    {
        foreach (var gameObject in _pool)
        {
            gameObject.TryGetComponent(out Enemy enemy);
            enemy.LevelUp(_damageIncrease, _healthIncrease);
            gameObject.TryGetComponent(out EnemyMover enemyMover);
            enemyMover.LevelUp(_speedIncrease);
        }
    }

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.First(obj => obj.activeSelf == false);
        return result != null;
    }
}
