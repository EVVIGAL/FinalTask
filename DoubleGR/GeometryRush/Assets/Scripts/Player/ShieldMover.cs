using UnityEngine;

public class ShieldMover : MonoBehaviour
{
    [SerializeField] private GameObject _center;
    [SerializeField] private float _speed;

    private Vector3 _axis = new(0, 0, 1);

    private void Start()
    {
        if (TryGetComponent(out Shield shield))
            _center = shield.Center;
    }

    private void Update()
    {
        transform.RotateAround(_center.transform.position, _axis, _speed * Time.deltaTime);
    }
}
