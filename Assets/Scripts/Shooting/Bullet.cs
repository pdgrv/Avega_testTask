using UnityEngine;
using Avega.HealthSystem;

namespace Avega.Shooting
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;

        private void Update()
        {
            transform.position += _speed * Time.deltaTime * transform.forward;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damage);
            }

            SelfDestroy();
        }

        private void SelfDestroy() => Destroy(gameObject);
    }
}