using Avega.HealthSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Camera _headCamera;

    public Health Health => _health;
    public Camera HeadCamera => _headCamera;
}
