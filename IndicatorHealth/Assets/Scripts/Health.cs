using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;
        
        private float _targetValue;
        
        public float Current { get; private set; }
        public float Max => _maxHealth; 

        public event Action Changed;

        private void Start()
        {
            _targetValue = 0.2f;
        }

        public void TakeDamage()
        {
            if(_targetValue < 0)
                return;

            Current = Mathf.Clamp(Current - _targetValue, 0, Max);
            Changed?.Invoke();
        }

        public void Heal()
        {
            if(_targetValue < 0)
                return;

            Current = Mathf.Clamp(Current + _targetValue, 0, Max);
            Changed?.Invoke();
        }
    }
}