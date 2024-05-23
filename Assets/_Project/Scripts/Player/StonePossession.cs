using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class StonePossession : MonoBehaviour
    {
        private bool hasStone = false;
        
        public void AddStone()
        {
            this.hasStone = true;
        }
        
        public void RemoveStone()
        {
            this.hasStone = false;
        }
        
        public bool HasStone()
        {
            return this.hasStone;
        }
    }    
}

