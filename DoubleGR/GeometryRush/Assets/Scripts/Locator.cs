using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Locator : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies = new();

    private CircleCollider2D _collider;

    private void Start()
    {
        _collider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            _enemies.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            _enemies.Remove(enemy);
        }
    }

    public Enemy GetTarget()
    {
        float distance;
        float minDistance = _collider.radius;
        Enemy nearestEnemy = null;

        foreach (Enemy enemy in _enemies)
        {
            distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    public int GetEnemiesQuantity()
    {
        return _enemies.Count;
    }
}
