using System;
using Unity.VisualScripting;
using UnityEngine;

namespace _Project.Scripts.Variables
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "ScriptableObjects/Variables/FloatVariable", order = 0)]
    public class FloatVariable : ScriptableObject
    {
        public event Action OnValueChanged;

        [SerializeField] public float Value;
        
        public float GetValue()
        {
            return this.Value;
        }

        public void SetValue(float value)
        {
            this.Value = value;
            OnValueChanged?.Invoke();
        }
        
        public void SubtractValue(float value)
        {
            this.Value -= value;
            OnValueChanged?.Invoke();
        }
    }
}