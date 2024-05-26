using System;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PuzzlePossession : MonoBehaviour
    {
        [SerializeField] private bool[] PuzzlePieces = new bool[4];
        private int PuzzlePiecesCollected = 0;
        public bool ReadyToEscape = false;

        public event Action OnPuzzleCollect;

        public event Action OnEscape;

        public void AddPuzzlePiece()
        {
            this.PuzzlePieces[this.PuzzlePiecesCollected] = true;
            this.PuzzlePiecesCollected++;
            OnPuzzleCollect?.Invoke();
        }
        
        public void Escape()
        {
            if (this.PuzzlePiecesCollected != 4) return;
            
            this.ReadyToEscape = true;
            OnEscape?.Invoke();
            
            Time.timeScale = 0;
        }
    }
}