using UnityEngine;

namespace Avega.Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();    
        }
        public void PlayClip(AudioClip clip)
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}