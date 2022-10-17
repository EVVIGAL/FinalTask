using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _destroyParticles;
    [SerializeField] private float _damage;
    [SerializeField] private float _health;
    [SerializeField] private int _value;

    public event UnityAction<GameObject, int> WasDeactivated;

    private float _currentHealth;

    private void OnEnable()
    {       
        _currentHealth = _health;
    }

    private void OnDisable()
    {
        WasDeactivated?.Invoke(this.gameObject, _value);
    }

    private void Update()
    {
        if (_currentHealth <= 0)
        {
            Deactivate();
        }
    }

    public float DealDamage()
    {
        Deactivate();
        return _damage;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
    }

    public void LevelUp(float damage, float health)
    {
        _damage += damage;
        _health += health;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        Instantiate(_destroyParticles, transform.position, Quaternion.identity);
        _currentHealth = _health;
    }
}
