using Avega.Inventory;
using UnityEngine;

namespace Avega.Shooting
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private FP_Input _playerInput;
        [SerializeField] private Bullet _bulletTemplate;
        [SerializeField] private float _shootRate;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private PlayerBag _playerBag;

        private Color _bulletsColor = Color.grey;

        private float _shootTimer = 0f;

        private void OnEnable()
        {
            _playerBag.CubePickedUp += OnCubePickedUp;
        }

        private void OnDisable()
        {
            _playerBag.CubePickedUp -= OnCubePickedUp;
        }

        private void OnCubePickedUp(Color pickedColor, int count)
        {
            _bulletsColor = pickedColor;
        }

        private void Update()
        {
            _shootTimer -= Time.deltaTime;

            if (_playerInput.Shoot() && _shootTimer <= 0)
            {
                _shootTimer = _shootRate;
                Shoot();
            }
        }

        private void Shoot()
        {
            Instantiate(_bulletTemplate, _shootPoint.position, _shootPoint.rotation, null)
                .SetColor(_bulletsColor);
        }
    }
}