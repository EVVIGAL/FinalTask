using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : Pool
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _timeBtwSpawn;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _lvlUpDamage;
    [SerializeField] private float _lvlUpHealth;
    [SerializeField] private float _lvlUpSpeed;

    public event UnityAction<GameObject> isSpawned;

    private int _numObjects = 1;
    private float _radius = 12f;

    private void Start()
    {
        _damageIncrease = _lvlUpDamage;
        _healthIncrease = _lvlUpHealth;
        _speedIncrease = _lvlUpSpeed;
        Initialize(_enemy);
    }

    private void Update()
    {
        if (_spawnDelay > 0)
            _spawnDelay -= Time.deltaTime;

        if (_spawnDelay <= 0 && _player.isActiveAndEnabled)
        {
            for(int i=0; i< _numObjects; i++)
            {
                if (TryGetObject(out GameObject enemy))
                {
                    Spawn(enemy);
                    isSpawned?.Invoke(enemy);
                    _spawnDelay = _timeBtwSpawn;
                }
            }          
        }
    }

    private void Spawn(GameObject enemy)
    {
        Vector3 center = transform.position;
        Vector3 position = RandomCircle(center, _radius);
        enemy.transform.position = position;
        enemy.SetActive(true);
    }

    private Vector3 RandomCircle(Vector3 center, float radius)
    {
        float angle = Random.value * 360;
        Vector3 position;
        position.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        position.y = center.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        position.z = center.z;
        return position;
    }
}
