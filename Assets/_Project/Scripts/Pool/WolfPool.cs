using _Project.Scripts.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WolfPool", menuName = "ScriptableObjects/WolfPool", order = 1)]
    public class WolfPool : ScriptableObject
{
    [SerializeField] 
    private GameObject _wolfPrefab;
    
    private readonly Stack<GameObject> WolfPoolStack = new Stack<GameObject>();

    public void Initialize(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject stone = Instantiate(this._wolfPrefab);
            stone.SetActive(false);
            this.WolfPoolStack.Push(stone);
        }
    }

    public void SpawnWolf(Vector3 position)
    {
        if (this.WolfPoolStack.Count <= 0) return;

        GameObject wolf = this.WolfPoolStack.Pop();
        wolf.transform.position = position;
        wolf.SetActive(true);
    }

    private void DisableWolf(GameObject wolf)
    {
        wolf.SetActive(false);
    }
}
