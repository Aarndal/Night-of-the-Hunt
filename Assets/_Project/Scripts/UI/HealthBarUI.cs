using _Project.Scripts.Variables;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI
{
    public class HealthBarUI : MonoBehaviour
    {
        [SerializeField] private Image NegativeHealthBar;
        [SerializeField] private FloatVariable HealthValue;
        [SerializeField] private float MaxHealth = 100f;
        
        private void Start()
        {
            this.NegativeHealthBar.fillAmount = 0f;
            Invoke(nameof(DelayedStart), 0.1f);
        }
        
        private void DelayedStart()
        {
            this.HealthValue.OnValueChanged += UpdateHealthBar;
        }
        
        private void UpdateHealthBar()
        {
            this.NegativeHealthBar.fillAmount = (this.MaxHealth - this.HealthValue.GetValue()) / this.MaxHealth;
        }
    }
}