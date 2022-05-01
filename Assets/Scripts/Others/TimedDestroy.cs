using System.Collections;
using UnityEngine;

namespace Avega.Others
{
    public class TimedDestroy : MonoBehaviour
    {
        [SerializeField] private float _time = 10f;

        private void Start()
        {
            StartCoroutine(TimedDestroying(_time));
        }

        private IEnumerator TimedDestroying(float time)
        {
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
        }
    }
}