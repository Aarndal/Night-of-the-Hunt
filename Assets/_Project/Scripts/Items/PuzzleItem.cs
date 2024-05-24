using System;
using _Project.Scripts.Player;
using UnityEngine;

namespace _Project.Scripts.Items
{
    public class PuzzleItem : MonoBehaviour, ICollectable
    {

        public event Action<GameObject> OnCollect;

        public void Collect(Collider2D collector)
        {
            Debug.Log("Puzzle Piece Collected");
            if (collector.CompareTag("Player") == false) return;
            
            collector.GetComponent<PuzzlePossession>().AddPuzzlePiece();
            OnCollect?.Invoke(this.gameObject);

            
            
            Destroy(this.gameObject);
        }
    }
}