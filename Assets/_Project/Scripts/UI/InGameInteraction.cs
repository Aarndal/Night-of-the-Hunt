using System;
using System.Collections.Generic;
using _Project.Scripts.Player;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

namespace _Project.Scripts.UI
{
    public class InGameInteraction : MonoBehaviour
    {
        [SerializeField] private List<Sprite> PuzzleSprites;
        private VisualElement PuzzleImageOne;
        private VisualElement PuzzleImageTwo;
        private VisualElement PuzzleImageThree;
        private VisualElement PuzzleImagFour;
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
            this.PuzzleImageOne = root.Q<VisualElement>("PuzzleImageOne");
            this.PuzzleImageOne.visible = false;
            this.PuzzleImageTwo = root.Q<VisualElement>("PuzzleImageTwo");
            this.PuzzleImageTwo.visible = false;
            this.PuzzleImageThree = root.Q<VisualElement>("PuzzleImageThree");
            this.PuzzleImageThree.visible = false;
            this.PuzzleImagFour = root.Q<VisualElement>("PuzzleImageFour");
            this.PuzzleImagFour.visible = false;

            GameObject player = GameObject.FindWithTag("Player");
            GetInput input = player.GetComponent<GetInput>();
            
            input.DrinkEvent += DrinkWine;
            input.DropMeatPieEvent += DropMeatPie;
            
            player.GetComponent<PuzzlePossession>().OnPuzzleCollect += CollectPuzzle;
            

        }

        private void CollectPuzzle()
        {
            if (this.CurrentPuzzleIndex >= this.PuzzleSprites.Count) return;
            
            switch (this.CurrentPuzzleIndex)
            {
                case 0:
                    this.PuzzleImageOne.visible = true;
                    break;
                case 1:
                    this.PuzzleImageTwo.visible = true;
                    break;
                case 2:
                    this.PuzzleImageThree.visible = true;
                    break;
                case 3:
                    this.PuzzleImagFour.visible = true;
                    break;
            }
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