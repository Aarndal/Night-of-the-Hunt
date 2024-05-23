using System;
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
            
            if (!temp.HasStone()) temp.AddStone();
            OnCollect?.Invoke(this.gameObject);
        }
    }

}