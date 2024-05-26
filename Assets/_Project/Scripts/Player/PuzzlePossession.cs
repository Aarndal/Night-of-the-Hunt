using System;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PuzzlePossession : MonoBehaviour
    {
        [SerializeField] private bool[] PuzzlePieces = new bool[4];
        private int PuzzlePiecesCollected = 0;

        public event Action OnPuzzleCollect;

        public event Action OnPuzzleComplete;

        public void AddPuzzlePiece()
        {
            this.PuzzlePieces[this.PuzzlePiecesCollected] = true;
            this.PuzzlePiecesCollected++;
            OnPuzzleCollect?.Invoke();

            if (this.PuzzlePiecesCollected == 4) OnPuzzleComplete?.Invoke();
        }
    }
}