using UnityEngine;

public class Tower : Pool
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Locator _locator;
    [SerializeField] private float _timeBtwShoot;

    private Enemy targetEnemy;
    private float _shootDelay;

    private void Start()
    {
        gameObject.SetActive(true);
        Initialize(_bullet);
    }

    private void Update()
    {
        ShotAtTarget();
    }

    private void Shoot(Enemy target, GameObject bullet, Vector3 position)
    {
        bullet.SetActive(true);
        bullet.transform.position = position;

        if (bullet.TryGetComponent(out Bullet projectile))
            projectile.SetTarget(target);
    }

    private void ShotAtTarget()
    {
        if (_shootDelay > 0)
            _shootDelay -= Time.deltaTime;

        if (_locator.GetEnemiesQuantity() > 0)
        {
            targetEnemy = _locator.GetTarget();

            if (_shootDelay <= 0 && targetEnemy != null)
            {
                if (TryGetObject(out GameObject bullet))
                {
                    Shoot(targetEnemy, bullet, transform.position);
                    _shootDelay = _timeBtwShoot;
                }
            }
        }
    }
}
