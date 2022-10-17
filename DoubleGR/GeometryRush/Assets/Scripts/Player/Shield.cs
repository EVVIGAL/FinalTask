using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Shield : MonoBehaviour
{
    [SerializeField] private GameObject _particles;
    [SerializeField] private float _damage;
    [SerializeField] private float _rebirthTime;

    private string _methodName = "ReActivate";

    public GameObject Center { get; private set; }

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

    public void SetCenter(GameObject center)
    {
        Center = center;
    }

    private void ReActivate()
    {
        gameObject.SetActive(true);
    }
}
