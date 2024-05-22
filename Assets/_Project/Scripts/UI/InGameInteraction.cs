using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.Scripts.UI
{
    public class InGameInteraction : MonoBehaviour
    {
        private VisualElement HeartBar;
        private VisualElement Dragger;
        private VisualElement Bar;
        
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
            this.CurrentMeatPieIndex = 8;
            this.CurrentWineIndex = 4;
            
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            this.HeartBar = root.Q<VisualElement>("HealthBar");
            this.Dragger = root.Q<VisualElement>("unity-dragger");


            AddElements();
        }

        private void AddElements()
        {
            this.Bar = new VisualElement();
            this.Dragger.Add(this.Bar);
            this.Bar.name = "Bar";
            this.Bar.AddToClassList("bar");
        }
        
        private void CollectPuzzle()
        {
            if (this.CurrentPuzzleIndex >= this.PuzzleSprites.Count) return;
            
            this.CurrentPuzzleIndex++;
        }
        
        private void LoosePieScore()
        {
            if (this.CurrentMeatPieIndex < 0) return;
            
            this.CurrentMeatPieIndex--;
            
            // Remove one Piece of the MeatPie
        }
        
        private void LooseWineScore()
        {
            if (this.CurrentWineIndex < 0) return;
            
            this.CurrentWineIndex--;
            
            // Remove one Glass of Wine
        }
    }
}