using Avega.HealthSystem;
using UnityEngine;

namespace Avega.Inventory.ColoredCubes
{
    public class EnemyCubeSpawner : MonoBehaviour
    {
        [SerializeField] private Health _enemyHealth;
        [SerializeField] private ColoredCube[] _cubesPool;

        private void OnEnable()
        {
            _enemyHealth.Died += OnEnemyDied;
        }

        private void OnDisable()
        {
            _enemyHealth.Died -= OnEnemyDied;
        }

        private void OnEnemyDied()
        {
            DropCube();
        }

        private void DropCube()
        {
            Instantiate(_cubesPool[Random.Range(0, _cubesPool.Length)], transform.position, Quaternion.identity, null);
        }
    }
}