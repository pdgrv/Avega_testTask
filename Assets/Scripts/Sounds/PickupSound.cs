using Avega.Inventory;
using UnityEngine;

namespace Avega.Sounds
{
    public class PickupSound : MonoBehaviour
    {
        [SerializeField] private PlayerBag _bag;
        [SerializeField] private AudioClip _pickupClip;
        [SerializeField] private SoundPlayer _soundPlayer;

        private void OnEnable()
        {
            _bag.CubePickedUp += OnCubePickedUp;
        }

        private void OnDisable()
        {
            _bag.CubePickedUp-=OnCubePickedUp;
        }

        private void OnCubePickedUp(Color arg1, int arg2)
        {
            _soundPlayer.PlayClip(_pickupClip);
        }
    }
}