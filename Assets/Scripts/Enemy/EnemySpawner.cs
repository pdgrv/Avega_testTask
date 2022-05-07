using UnityEngine;
using Avega.Others;

namespace Avega.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Enemy _enemyTemplate;
        [SerializeField] private float _spawnCooldown = 3f;
        [SerializeField] private float _playerMinSpawnDistance = 10f;
        [SerializeField] private Vector3 _spawnRange = new Vector3(100f, 0, 100f);
        [SerializeField] private LayerMask _wallLayer;

        private float _time;

        private void Update()
        {
            _time += Time.deltaTime;

            if (_time > _spawnCooldown)
            {
                _time = 0;

                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            Vector3 spawnPoint = CalculateSpawnPosition();
            Instantiate(_enemyTemplate, spawnPoint, Quaternion.identity)
                .Init(_player);
        }

        private Vector3 CalculateSpawnPosition()
        {
            Vector3 spawnPoint;

            do
            {
                spawnPoint = transform.position
                    + new Vector3(Random.Range(-_spawnRange.x / 2, _spawnRange.x / 2), 0, Random.Range(-_spawnRange.z / 2, _spawnRange.z / 2));
            } while (CheckSpawnConditions(spawnPoint));

            return spawnPoint;
        }

        private bool CheckSpawnConditions(Vector3 spawnPoint)
        {
            if (Vector3.Distance(spawnPoint, _player.transform.position) < _playerMinSpawnDistance)
                return true;

            if (_player.HeadCamera.IsPointInSight(spawnPoint, _wallLayer))
                return true;

            return false;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position, new Vector3(_spawnRange.x, 0, _spawnRange.z));
        }
    }
}