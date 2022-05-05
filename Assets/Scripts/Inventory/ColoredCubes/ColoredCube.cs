using UnityEngine;

namespace Avega.Inventory.ColoredCubes
{
    public class ColoredCube : MonoBehaviour, IPickable
    {
        [SerializeField] private Color _color;

        public Color Color => _color;

        private void Start()
        {
            GetComponent<Renderer>().material.color = _color;
        }

        public void Pickup() => Destroy(gameObject);
    }
}