using _Project.Scripts.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSpawner : MonoBehaviour
{
    [SerializeField] 
    private WolfPool _wolfPool;
    [SerializeField, Range(0, 100)] 
    private int _spawnRadius;
    [SerializeField, Range(0, 100)] 
    private int _spawnCount;

    [SerializeField] 
    private int _timeToSpawn = 10;

    private float _timer = 0.0f;
    
    private void Start()
    {
        this._wolfPool.Initialize(this._spawnCount);
    }

    private void Update()
    {
        // add the elapsed time since last frame to the timer
        this._timer += Time.deltaTime;

        // if more than 10 seconds have passed
        if (!(this._timer > this._timeToSpawn)) return;
        this._timer = 0.0f;

        Vector3 randomPosition = new Vector3(Random.Range(-this._spawnRadius, this._spawnRadius), Random.Range(-this._spawnRadius, this._spawnRadius), 0);
        this._wolfPool.SpawnWolf(randomPosition);
    }
}
