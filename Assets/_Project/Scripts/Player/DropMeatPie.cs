using System;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class DropMeatPie : MonoBehaviour
    {
        [SerializeField] private int RemainingMeatPie = 8;
        [SerializeField] private GameObject MeatPiePrefab;
        
        private void Start()
        {
            GetInput input = GetComponent<GetInput>();
            
            input.DropMeatPieEvent += DropMeatPieFunc;
        }

        private void DropMeatPieFunc()
        {
            if (this.MeatPiePrefab == null) return;
            if (this.RemainingMeatPie <= 0) return;
            Debug.Log("Dropping Meat Pie");
            this.RemainingMeatPie--;
            
            Instantiate(this.MeatPiePrefab, transform.position, Quaternion.identity);
        }
    }
}