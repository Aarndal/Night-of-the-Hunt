using System;
using System.Collections.Generic;
using _Project.Scripts.Player;
using UnityEngine;

namespace _Project.Scripts.Items
{
    public class StoneItem : MonoBehaviour, ICollectable
    {
        public event Action<GameObject> OnCollect;

        public void Collect(Collider2D collector)
        {
            if (collector.CompareTag("Player") == false) return;

            StonePossession temp = collector.GetComponent<StonePossession>();

            if (!temp.HasStone()) temp.AddStone(this.gameObject);
            OnCollect?.Invoke(this.gameObject);
        }

        public void StartThrow()
        {
            StartCoroutine(nameof(Throw));
        }

        public void Throw()
        {
            if (GetComponent<Rigidbody2D>().velocity != Vector2.zero) return;
            
            StopCoroutine(nameof(Throw));
            this.gameObject.SetActive(false);
        }
    }
}