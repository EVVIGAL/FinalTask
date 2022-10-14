using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Shield : MonoBehaviour
{
    [SerializeField] private GameObject _particles;
    [SerializeField] private float _damage;
    [SerializeField] private float _rebirthTime;

    private string _methodName = "ReActivate";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            gameObject.SetActive(false);
            Instantiate(_particles, transform.position, Quaternion.identity);
            Invoke(_methodName, _rebirthTime);
        }
    }

    private void ReActivate()
    {
        gameObject.SetActive(true);
    }
}
