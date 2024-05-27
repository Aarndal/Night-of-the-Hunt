using System;
using _Project.Scripts.Player;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class EndGameState : MonoBehaviour
    {
        [SerializeField] private GameObject LoosePanel;
        [SerializeField] private GameObject WinPanel;
        [SerializeField] private GameObject ButtonPanel;

        private void Start()
        {
            // Find Player Object
            GameObject player = GameObject.FindWithTag("Player");
            
            player.GetComponent<PlayerHealth>().OnPlayerDeath += ShowLoosePanel;
            player.GetComponent<PuzzlePossession>().OnEscape += ShowWinPanel;
        }

        private void ShowLoosePanel()
        {
            this.LoosePanel.SetActive(true);
            this.ButtonPanel.SetActive(true);
        }

        private void ShowWinPanel()
        {
            this.WinPanel.SetActive(true);
            this.ButtonPanel.SetActive(true);
        }
        
    }
}