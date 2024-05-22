using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Items
{
    public class StoneSpawner : MonoBehaviour
    {
        [SerializeField] private StonePool StonePool;
        [SerializeField, Range(0, 100)] private int SpawnRadius;
        [SerializeField, Range(0, 100)] private int SpawnCount;

        private float Timer = 0.0f;
        [SerializeField] private int TimeToSpawn = 10;
        
        private void Start()
        {
            this.StonePool.Initialize(this.SpawnCount);
        }
        
        private void Update()
        { 
            // add the elapsed time since last frame to the timer
            this.Timer += Time.deltaTime;  

            // if more than 10 seconds have passed
            if (!(this.Timer > this.TimeToSpawn)) return;
            this.Timer = 0.0f;
            
            Vector3 randomPosition = new Vector3(Random.Range(-this.SpawnRadius, this.SpawnRadius), 0, Random.Range(-this.SpawnRadius, this.SpawnRadius));
            this.StonePool.SpawnStone(randomPosition);
        }

        void OnDrawGizmosSelected()
        {
            Handles.color = Color.cyan;
            Handles.DrawWireArc(this.transform.position, Vector3.up, Vector3.forward, 360, this.SpawnRadius);

        }
    }
}