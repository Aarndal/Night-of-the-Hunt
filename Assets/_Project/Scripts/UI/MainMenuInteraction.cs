using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.Scripts.UI
{
    public enum EName
    {
        Aaron,
        Alex,
        Leonie,
        Marcel,
        Regina
    }

    public class MainMenuInteraction : MonoBehaviour
    {
        private VisualElement root;
        private VisualElement Background;
        private Button StartButton;
        private Button SettingsButton;
        private Button CreditsButton;
        private Button ExitButton;

        private VisualElement CreditsPanel;
        private Label Aaron;
        private Label Alex;
        private Label Leonie;
        private Label Marcel;
        private Label Regina;

        private VisualElement StartPanel;
        
        private bool StartZoom = false;

        private void Awake()
        {
            this.root = GetComponent<UIDocument>().rootVisualElement;
            this.StartButton = root.Q<Button>("StartButton");
            this.SettingsButton = root.Q<Button>("SettingsButton");
            this.CreditsButton = root.Q<Button>("CreditsButton");
            this.ExitButton = root.Q<Button>("QuitButton");

            this.Background = root.Q<VisualElement>("BackGround");
            this.CreditsPanel = root.Q<VisualElement>("CreditsPanel");
            this.CreditsPanel.style.visibility = Visibility.Hidden;
            this.StartPanel = root.Q<VisualElement>("StartPanel");
            this.StartPanel.style.visibility = Visibility.Hidden;

            this.Aaron = root.Q<Label>("Aaron");
            this.Alex = root.Q<Label>("Alex");
            this.Leonie = root.Q<Label>("Leonie");
            this.Marcel = root.Q<Label>("Marcel");
            this.Regina = root.Q<Label>("Regina");

            this.StartButton.RegisterCallback<ClickEvent>(OnStartButtonClicked);
            this.SettingsButton.RegisterCallback<ClickEvent>(OnSettingsButtonClicked);
            this.CreditsButton.RegisterCallback<ClickEvent>(OnCreditsButtonClicked);
            this.ExitButton.RegisterCallback<ClickEvent>(OnExitButtonClicked);

            this.Aaron.RegisterCallback<ClickEvent>(evt => CreditsTextClick(evt, EName.Aaron));
            this.Alex.RegisterCallback<ClickEvent>(evt => CreditsTextClick(evt, EName.Alex));
            this.Leonie.RegisterCallback<ClickEvent>(evt => CreditsTextClick(evt, EName.Leonie));
            this.Marcel.RegisterCallback<ClickEvent>(evt => CreditsTextClick(evt, EName.Marcel));
            this.Regina.RegisterCallback<ClickEvent>(evt => CreditsTextClick(evt, EName.Regina));
        }

        private void Update()
        {
            if (this.StartZoom == false) return;
            
            VisualElement targetElement = this.Background;
            //Vector2 targetPosition = this.StartPanel.transform.position; // Zielposition (z. B. in Pixeln)
            Vector2 targetPosition = new Vector2(-1920, -1080); // Zielposition (z. B. in Pixeln)
            float zoomFactor = 2f; // Zoomfaktor
        
            // Berechnen Sie die neuen Transformationswerte
            Vector3 offset = new Vector3(targetPosition.x, targetPosition.y, 0)  - targetElement.transform.position;
            Vector3 newScale = targetElement.transform.scale * zoomFactor;

            // Animieren Sie die Transformation
            targetElement.transform.position += offset * Time.deltaTime;
            targetElement.transform.scale = Vector3.Lerp(targetElement.transform.scale, newScale, Time.deltaTime);
        }

        private void OnStartButtonClicked(ClickEvent evt)
        {
            Debug.Log("Start Button Clicked");
            this.StartZoom = true;
            this.CreditsPanel.style.visibility = Visibility.Hidden;
            this.StartPanel.style.visibility = Visibility.Visible;
            
            
            Invoke(nameof(StartGameLoad), 2.5f);
        }

        private void StartGameLoad()
        {
            SceneLoader.Instance.LoadScene(EScene.GameScene);
        }

        private void OnSettingsButtonClicked(ClickEvent evt)
        {
            Debug.Log("Settings Button Clicked");
        }

        private void OnCreditsButtonClicked(ClickEvent evt)
        {
            this.CreditsPanel.style.visibility = Visibility.Visible;
            this.StartPanel.style.visibility = Visibility.Hidden;
        }

        private void CreditsTextClick(ClickEvent evt, EName name)
        {
            switch (name)
            {
                case EName.Aaron:
                    Application.OpenURL("https://www.github.com/Aarndal");
                    break;
                case EName.Alex:
                    Application.OpenURL("https://www.github.com/alexsolomko");
                    break;
                case EName.Leonie:
                    Application.OpenURL("https://www.instagram.com/busywith.art/");
                    break;
                case EName.Marcel:
                    Application.OpenURL("https://sihnor.github.io/");
                    break;
                case EName.Regina:
                    Application.OpenURL("https://www.artstation.com/regina_poida");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(name), name, null);
            }
        }

        private void OnExitButtonClicked(ClickEvent evt)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}