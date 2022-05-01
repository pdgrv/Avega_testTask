using UnityEngine;
using Avega.HealthSystem;
using UnityEngine.UI;
using TMPro;

namespace Avega.UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Health _targetHealth;
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _healthText;

        private void OnEnable()
        {
            _targetHealth.Changed += OnHealthChanged;
        }

        private void OnDisable()
        {
            _targetHealth.Changed -= OnHealthChanged;
        }

        private void OnHealthChanged(int value, int maxValue)
        {
            float healthPercent = (float)value / maxValue;

            _healthText.text = value.ToString();
            _slider.value = healthPercent;
        }
    }
}