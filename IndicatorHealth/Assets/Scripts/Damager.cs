using DefaultNamespace;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private Health _health;
    
    private float _targetValue;

    private void Start()
    {
        _targetValue = 0.2f;
    }

    public void Activate()
    {
        _health.TakeDamage(_targetValue);
    }
}
