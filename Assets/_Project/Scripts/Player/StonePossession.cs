using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class StonePossession : MonoBehaviour
    {
        private GameObject Stone = null;
        private bool hasStone = false;
        
        public void AddStone(GameObject stone)
        {
            this.hasStone = true;
            this.Stone = stone;
        }
        
        public void RemoveStone()
        {
            this.hasStone = false;
            this.Stone = null;
        }
        
        public bool HasStone()
        {
            return this.hasStone;
        }
        
        public GameObject GetStone()
        {
            return this.Stone;
        }
    }    
}

