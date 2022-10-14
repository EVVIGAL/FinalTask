using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private Rigidbody2D _rigidBody;
    private Player _target;

    private void OnEnable()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _target = FindObjectOfType<Player>();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void SetTarget()
    {
        _rigidBody.velocity = - transform.position.normalized * _speed;
    }

    public float DealDamage()
    {
        Destroy(gameObject);
        return _damage;
    }
}
