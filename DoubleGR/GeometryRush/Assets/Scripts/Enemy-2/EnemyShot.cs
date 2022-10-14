using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : State
{
    [SerializeField] private EnemyBullet _enemyBullet;
    [SerializeField] private float _timeBtwShoot;
    [SerializeField] private float _shootDelay;

    private Player _target;

    private void OnEnable()
    {
        _target = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (_shootDelay > 0)
            _shootDelay -= Time.deltaTime;

        if (_shootDelay <= 0 && _target != null)
        {
            Shoot();
            _shootDelay = _timeBtwShoot;
        }
    }

    private void Shoot()
    {
        Instantiate(_enemyBullet, transform.position, Quaternion.identity).SetTarget();
    }
}
