using System;
using UnityEngine;

namespace Avega.HealthSystem
{
    public class Health : MonoBehaviour, IDamageable
    {
        public event Action<int, int> Changed;
        public event Action Died;

        [SerializeField] private int _maxHealth;

        private int _currentHealth;

        private void Start()
        {
            ChangeHealth(_maxHealth);
        }

        public void TakeDamage(int damage)
        {
            ChangeHealth(-damage);
        }

        private void ChangeHealth(int value)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + value, 0, _maxHealth);

            Changed?.Invoke(_currentHealth, _maxHealth);

            if (_currentHealth <= 0)
                Die();
        }

        private void Die()
        {
            Died?.Invoke();

            Destroy(transform.root.gameObject);
        }
    }
}