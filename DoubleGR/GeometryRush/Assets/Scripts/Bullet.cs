using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private Rigidbody2D _rigidBody;

    public float Damage => _damage;

    private void OnEnable()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    public void SetTarget(Enemy target)
    {
        if(target != null)
        {
            _rigidBody.velocity = (target.transform.position - transform.position).normalized * _speed;
        }
    }

    public void DamageUp(float damageUp)
    {
        _damage += damageUp;
    }
}
