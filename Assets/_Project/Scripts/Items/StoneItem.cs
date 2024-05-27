using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Player;
using UnityEngine;

namespace _Project.Scripts.Items
{
    public class StoneItem : MonoBehaviour, ICollectable
    {
        public event Action<GameObject> OnCollect;
        private bool IsThrown = false;

        public void Collect(Collider2D collector)
        {
            if (collector.CompareTag("Player") == false || this.IsThrown) return;

            StonePossession temp = collector.GetComponent<StonePossession>();

            if (temp.HasStone()) return;
            
            temp.AddStone(this.gameObject);
            OnCollect?.Invoke(this.gameObject);

        }

        public void StartThrow()
        {
            this.IsThrown = true;
            StartCoroutine(nameof(Throw));
            
        }

        public IEnumerator Throw()
        {
            yield return new WaitUntil(() => (GetComponent<Rigidbody2D>().velocity == Vector2.zero));
            StopCoroutine(nameof(Throw));
            this.gameObject.SetActive(false);
        }
    }
}