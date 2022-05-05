using Avega.Inventory.ColoredCubes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Avega.Inventory
{
    public class PlayerBag : MonoBehaviour
    {
        public event Action<Color, int> CubePickedUp;

        private Dictionary<Color, int> _pickedColoredCubes = new Dictionary<Color, int>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IPickable pickable))
            {
                if (pickable is ColoredCube cube)
                {
                    if (_pickedColoredCubes.ContainsKey(cube.Color))
                        _pickedColoredCubes[cube.Color]++;
                    else
                        _pickedColoredCubes.Add(cube.Color, 1);

                    CubePickedUp?.Invoke(cube.Color, _pickedColoredCubes[cube.Color]);
                }

                Debug.Log(_pickedColoredCubes);

                pickable.Pickup();
            }
        }
    }
}