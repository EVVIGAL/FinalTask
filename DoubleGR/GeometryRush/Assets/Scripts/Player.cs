using UnityEngine;
using TMPro;

[RequireComponent(typeof(CircleCollider2D))]

public class Player : Pool
{
    [SerializeField] private MoneyCounter _moneyCounter;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Locator _locator;
    [SerializeField] private TMP_Text _atkSpeedDisplay;
    [SerializeField] private TMP_Text _damageDisplay;
    [SerializeField] private TMP_Text _atkSpdCostDisplay;
    [SerializeField] private TMP_Text _DamageUpCostDisplay;
    [SerializeField] private float _timeBtwShoot;

    private Enemy targetEnemy;
    private float _shootDelay;
    private float _koefOfAtkSpeedIncrease = 0.9f;
    private float _upDamage = 0.3f;
    private int _atkSpdUpCost;
    private int _IncresaseOfAtkSpdUpCost = 8;
    private int _damageUpCost;
    private int _IncreaseOfDamageUpCost = 8;
    private string _costTxt = "$ ";

    private void Start()
    {
        _damageUpCost = _IncreaseOfDamageUpCost;
        _DamageUpCostDisplay.text = _costTxt + _damageUpCost.ToString();
        _atkSpdUpCost = _IncresaseOfAtkSpdUpCost;
        _atkSpdCostDisplay.text = _costTxt + _atkSpdUpCost.ToString();
        gameObject.SetActive(true);
        Initialize(_bullet);
        _atkSpeedDisplay.text = "AtkSPD:\n" + (1 / _timeBtwShoot).ToString("#.##");

        if (_pool[0].TryGetComponent(out Bullet bullet))
            _damageDisplay.text = "Dmg:\n" + bullet.Damage.ToString();
    }

    private void Update()
    {
        ShotAtTarget();
    }

    public void DamageUpgrade()
    {
        if (_moneyCounter.Money >= _damageUpCost)
        {
            foreach (var item in _pool)
            {
                if (item.TryGetComponent(out Bullet projectile))
                    projectile.DamageUp(_upDamage);
            }

            if (_pool[0].TryGetComponent(out Bullet bullet))
                _damageDisplay.text = "Dmg:\n" + bullet.Damage.ToString();

            _moneyCounter.SpendMoney(_damageUpCost);
            _damageUpCost += _IncreaseOfDamageUpCost;
            _DamageUpCostDisplay.text = _costTxt + _damageUpCost.ToString();
        }
    }

    public void UpgradeAtkSpeed()
    {
        if (_moneyCounter.Money >= _atkSpdUpCost)
        {
            _timeBtwShoot *= _koefOfAtkSpeedIncrease;
            _atkSpeedDisplay.text = "AtkSPD:\n" + (1 / _timeBtwShoot).ToString("#.##");
            _moneyCounter.SpendMoney(_atkSpdUpCost);
            _atkSpdUpCost += _IncresaseOfAtkSpdUpCost;
            _atkSpdCostDisplay.text = _costTxt + _atkSpdUpCost.ToString();
        }
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
