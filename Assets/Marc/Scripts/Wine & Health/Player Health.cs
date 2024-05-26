using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Variables;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{
    [Tooltip("Player health")]
    [SerializeField] private FloatVariable HealthValue;
    [SerializeField] private float MaxHealth = 100f;
    
    public event Action OnPlayerDeath; 


    private void Start()
    {
        this.HealthValue.SetValue(this.MaxHealth);
    }

    public void GetDamage(float damage)
    {
        this.HealthValue.SubtractValue(damage);

        if(this.HealthValue.GetValue() <= 0f)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        GetComponent<PlayerInput>().enabled = false;
        OnPlayerDeath?.Invoke();

        Time.timeScale = 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            GetDamage(10f);
        }
    }
}