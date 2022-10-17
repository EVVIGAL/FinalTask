using UnityEngine;

public class EnemyShooter : State
{
    [SerializeField] private EnemyBullet _enemyBullet;
    [SerializeField] private float _timeBtwShoot;
    [SerializeField] private float _shootDelay;

    private void Update()
    {
        if (_shootDelay > 0)
            _shootDelay -= Time.deltaTime;

        if (_shootDelay <= 0 && Target != null)
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
