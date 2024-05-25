using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

namespace _Project.Scripts.UI
{
    public class InGameInteraction : MonoBehaviour
    {
        private VisualElement PuzzleContainer;
        [SerializeField] private List<Sprite> PuzzleSprites;
        private int CurrentPuzzleIndex;
        
        private VisualElement MeatPiImage;
        [SerializeField] private List<Sprite> MeatPieSprites;
        private int CurrentMeatPieIndex;
        
        private VisualElement WineImage;
        [SerializeField] private List<Sprite> WineSprites;
        private int CurrentWineIndex;


        private void Start()
        {
            this.CurrentPuzzleIndex = 0;
            this.CurrentMeatPieIndex = this.MeatPieSprites.Count - 1;
            this.CurrentWineIndex = this.WineSprites.Count - 1;
            
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            this.WineImage = root.Q<VisualElement>("WineImage");
            this.MeatPiImage = root.Q<VisualElement>("MeatPieImage");

            GameObject player = GameObject.FindWithTag("Player");
            GetInput input = player.GetComponent<GetInput>();
            
            input.DrinkEvent += DrinkWine;
            input.DropMeatPieEvent += DropMeatPie;
        }

        private void CollectPuzzle()
        {
            if (this.CurrentPuzzleIndex >= this.PuzzleSprites.Count) return;
            
            this.CurrentPuzzleIndex++;
        }
        
        private void DrinkWine()
        {
            if (this.CurrentWineIndex <= 0) return;
            
            this.CurrentWineIndex--;
            
            this.WineImage.style.backgroundImage = new StyleBackground(this.WineSprites[this.CurrentWineIndex]);
        }
        
        private void DropMeatPie()
        {
            if (this.CurrentMeatPieIndex <= 0) return;
            
            this.CurrentMeatPieIndex--;

            this.MeatPiImage.style.backgroundImage = new StyleBackground(this.MeatPieSprites[this.CurrentMeatPieIndex]);
        }
    }
}