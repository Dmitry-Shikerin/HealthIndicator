using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;
        
        public float Current { get; private set; }
        public float Max => _maxHealth; 

        public event Action Changed;
        
        public void TakeDamage(float damage)
        {
            if(damage < 0)
                return;

            Current = Mathf.Clamp(Current - damage, 0, Max);
            Debug.Log(Current);
            Changed?.Invoke();
        }

        public void Heal(float heal)
        {
            if(heal < 0)
                return;

            Current = Mathf.Clamp(Current + heal, 0, Max);
            Changed?.Invoke();
        }
    }
}