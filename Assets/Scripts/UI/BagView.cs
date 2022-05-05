using Avega.Inventory;
using Avega.Inventory.ColoredCubes;
using System.Collections.Generic;
using UnityEngine;

namespace Avega.UI
{
    public class BagView : MonoBehaviour
    {
        [SerializeField] private PlayerBag _playerBag;
        [SerializeField] private CubeView _cubeView;

        private Dictionary<Color, CubeView> _cubeViews = new Dictionary<Color, CubeView>();

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
            if (_cubeViews.ContainsKey(pickedColor))
                _cubeViews[pickedColor].Render(pickedColor, count);
            else
            {
                CubeView view = Instantiate(_cubeView, transform);
                view.Render(pickedColor, count);
                _cubeViews.Add(pickedColor, view);
            }
        }
    }
}
