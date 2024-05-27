using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Items
{
    public class PuzzleSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] PlacesToSpawn;
        
        [SerializeField] private StonePool PuzzlePool;
        
        [SerializeField] private GameObject WolfPackPrefab;
        
        private void Start()
        {
            this.PuzzlePool.Initialize(4);
            SpawnPuzzle();
            SpawnWolfPack();
        }
        
        private void SpawnPuzzle()
        {
            List<int> indexes = new List<int>();
            // Pick 4 random places to spawn the puzzle in the Place to spawn list and then remove them from the place to spawn list
            for (int i = 0; i < 4; i++)
            {
                int randomIndex = Random.Range(0, this.PlacesToSpawn.Length);

                while (indexes.Contains(randomIndex))
                {
                    randomIndex = Random.Range(0, this.PlacesToSpawn.Length);
                }
                indexes.Add(randomIndex);
                
                Vector3 position = this.PlacesToSpawn[randomIndex].transform.position;
                this.PuzzlePool.SpawnStone(position);
                
                this.PlacesToSpawn[randomIndex] = null;
            }
        }

        private void SpawnWolfPack()
        {
            foreach (GameObject places in this.PlacesToSpawn)
            {
                if (places == null) continue;
                
                Instantiate(this.WolfPackPrefab, places.transform.position, Quaternion.identity);
            }
        }
    }
}