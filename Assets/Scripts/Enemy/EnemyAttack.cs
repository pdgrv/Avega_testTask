using System;
using UnityEngine;

namespace Avega.Enemy
{
    public class EnemyAttack : MonoBehaviour, IEnemyState
    {
        public event Action Attacking;

        [SerializeField] private int _damage = 5;
        [SerializeField] private float _range = 3.5f;
        [SerializeField] private float _cooldown = 1f;

        private Player _player;

        private float _lastAttackTime;

        public void Init(Player player)
        {
            _player = player;
        }

        public void LocalUpdate()
        {
            _lastAttackTime -= Time.deltaTime;

            if (_lastAttackTime < 0)
            {
                _lastAttackTime = _cooldown;
                Attack();
            }
        }

        public bool CheckAttackRange()
        {
            return Vector3.Distance(transform.position, _player.transform.position) <= _range;
        }

        private void Attack()
        {
            _player.Health.TakeDamage(_damage);
            Attacking?.Invoke();
        }
    }
}