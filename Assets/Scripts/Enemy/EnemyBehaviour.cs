using UnityEngine;

namespace Avega.Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private EnemyMoving _enemyMoving;

        public void Init(Player player)
        {
            _enemyAttack.Init(player);
            _enemyMoving.Init(player);
        }

        private IEnemyState _currentState;

        private void Update()
        {
            switch (TrackState())
            {
                case EnemyState.Chase:
                    _currentState = _enemyMoving;
                    break;
                case EnemyState.Attack:
                    _currentState = _enemyAttack;
                    break;
            }

            _currentState.LocalUpdate();
        }

        private EnemyState TrackState()
        {
            if (_enemyAttack.CheckAttackRange())
                return EnemyState.Attack;
            else
                return EnemyState.Chase;
        }

        private enum EnemyState
        {
            Chase,
            Attack
        }
    }
}