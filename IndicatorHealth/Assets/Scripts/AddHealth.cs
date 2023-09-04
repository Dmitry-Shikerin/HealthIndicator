using UnityEngine;

public class AddHealth : MonoBehaviour
{
    [SerializeField] private ChangeHealth _changeHealth;

    private float _targetValue;

    private void Start()
    {
        _targetValue = 0.1f;
    }

    public void Activate()
    {
        _changeHealth.Activate(_targetValue);
    }
}
