using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace _Project.Scripts.Items
{
    [CreateAssetMenu(fileName = "StonePool", menuName = "ScriptableObjects/StonePool", order = 1)]
    public class StonePool : ScriptableObject
    {
        [SerializeField] private GameObject StonePrefab;
        private readonly Stack<GameObject> StonePoolStack = new Stack<GameObject>();
        
        [SerializeField] private bool IsReusable = false;

        /// <summary>
        ///  The pool is initialized with the given number of stones.
        /// </summary>
        /// <param name="count"></param>
        public void Initialize(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject stone = Instantiate(this.StonePrefab);
                stone.SetActive(false);
                this.StonePoolStack.Push(stone);
                
                // When the stone is collected, it is added back to the pool.
                stone.GetComponent<ICollectable>().OnCollect += DisableStone;
            }
        }

        /// <summary>
        /// The stone is spawned at the given position.
        /// </summary>
        /// <param name="position"></param>
        public void SpawnStone(Vector3 position)
        {
            if (this.StonePoolStack.Count <= 0) return;
            
            GameObject stone = this.StonePoolStack.Pop();
            stone.transform.position = position;
            stone.SetActive(true);
        }
        
        /// <summary>
        /// Disable the Stone and add it back to the pool.
        /// </summary>
        /// <param name="stone"></param>
        /// <param name="isReusable"></param>
        private void DisableStone(GameObject stone)
        {
            stone.SetActive(false);
            
            if (this.IsReusable) AddStone(stone);
        }
        
        /// <summary>
        /// When the stone is collected, it is added back to the pool.
        /// </summary>
        /// <param name="stone"></param>
        private void AddStone(GameObject stone)
        {
            this.StonePoolStack.Push(stone);
        }
    }
}