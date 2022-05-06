using Avega.Shooting;
using UnityEngine;

namespace Avega.Sounds
{
    public class WeaponSound : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private AudioClip _shootClip;
        [SerializeField] private SoundPlayer _soundPlayer;

        private void OnEnable()
        {
            _weapon.Shooted += OnWeaponShooted;
        }

        private void OnDisable()
        {
            _weapon.Shooted -= OnWeaponShooted;
        }

        private void OnWeaponShooted()
        {
            _soundPlayer.PlayClip(_shootClip);
        }
    }
}