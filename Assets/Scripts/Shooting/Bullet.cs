using UnityEngine;
using Avega.HealthSystem;

namespace Avega.Shooting
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Renderer _renderer;

        private void Start()
        {
            _rigidbody.velocity = _speed * transform.forward;
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

        public void SetColor(Color targetColor)
        {
            _renderer.material.color = targetColor;
        }
    }
}