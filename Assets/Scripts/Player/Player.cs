using Avega.HealthSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;

    public Health Health => _health;
}
