using System;
using UnityEngine;

namespace _Project.Scripts.Items
{
    public interface ICollectable
    {
        public event Action<GameObject> OnCollect;
        
        public void Collect(Collider2D collector);
    }
}