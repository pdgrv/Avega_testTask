using UnityEngine;
using UnityEngine.AI;

namespace Avega.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMoving : MonoBehaviour, IEnemyState
    {
        private Transform _playerTransform;

        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void Init(Player player)
        {
            _playerTransform = player.transform;
        }

        public void LocalUpdate()
        {
            _agent.SetDestination(_playerTransform.position);
        }
    }
}