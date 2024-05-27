using System;
using UnityEngine;

namespace _Project.Scripts.Items
{
    public class PieItem : MonoBehaviour
    {
        [SerializeField] private float TimeToDestroy = 10f;

        private void Start()
        {
            Destroy(this.gameObject, this.TimeToDestroy);
        }
    }
}