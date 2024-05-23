using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Tooltip("Player health")]
    [SerializeField] private float health;
                  
    public void GetDamage(float _damage)
    {
        health = health - _damage;

        if(health <= 0f)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        Destroy(this.gameObject);
    }
}