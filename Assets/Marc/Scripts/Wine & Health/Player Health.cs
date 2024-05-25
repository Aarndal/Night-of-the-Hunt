using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Variables;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Tooltip("Player health")]
    [SerializeField] private FloatVariable HealthValue;
    [SerializeField] private float MaxHealth = 100f;


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
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            GetDamage(10f);
        }
    }
}