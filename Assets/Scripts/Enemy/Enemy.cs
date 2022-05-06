using UnityEngine;

namespace Avega.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyBehaviour _enemyBehaviour;

        public void Init(Player player)
        {
            _enemyBehaviour.Init(player);
        }
    }
}