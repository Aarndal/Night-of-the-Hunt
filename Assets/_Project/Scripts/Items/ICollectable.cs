using UnityEngine;

namespace _Project.Scripts.Items
{
    public interface ICollectable
    {
        public void Collect(Collider2D collector);
    }
}