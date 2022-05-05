using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Avega.UI
{
    public class CubeView : MonoBehaviour
    {
        [SerializeField] private Image _selfImage;
        [SerializeField] private TMP_Text _countText;

        public void Render(Color color, int count)
        {
            _selfImage.color = color;
            _countText.text = count.ToString();
        }
    }
}