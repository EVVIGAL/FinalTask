using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMover : MonoBehaviour
{
    [SerializeField] private Player _center;
    [SerializeField] private float _speed;

    private Vector3 _axis = new(0, 0, 1);

    private void Start()
    {
        _center = FindObjectOfType<Player>();
    }

    private void Update()
    {
        transform.RotateAround(_center.transform.position, _axis, _speed * Time.deltaTime);
    }
}
