using System;
using UnityEngine;

namespace _Project.Scripts
{
    public class EntranceTeleport : MonoBehaviour
    {
        [SerializeField] private GameObject Exit;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            
            Debug.Log("Player entered the entrance");
            
            Vector2 exitPosition = this.Exit.transform.position + new Vector3(0, -5, 0);   
            other.transform.position = exitPosition;
        }
    }
}