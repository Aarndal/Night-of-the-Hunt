using System;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class DropMeatPie : MonoBehaviour
    {
        [SerializeField] private GameObject MeatPiePrefab;
        
        private void Start()
        {
            GetInput input = GetComponent<GetInput>();
            
            input.DropMeatPieEvent += DropMeatPieFunc;
        }

        private void DropMeatPieFunc()
        {
            if (this.MeatPiePrefab == null) return;
            Instantiate(this.MeatPiePrefab, transform.position, Quaternion.identity);
        }
    }
}