using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : State
{
    [SerializeField] private float _speed;

    private Player _player;

    private void OnEnable()
    {
        _player = FindObjectOfType<Player>();

        if (_player != null )
            LookAtPlayer();
    }

    private void Update()
    {
        if (_player != null)
            Move();
    }

    public void LevelUp(float speedIncrease)
    {
        _speed += speedIncrease;
    }

    private void LookAtPlayer()
    {
        var direction = transform.position - _player.transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
    }
}
