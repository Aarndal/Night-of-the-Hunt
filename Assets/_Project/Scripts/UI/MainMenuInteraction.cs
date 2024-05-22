using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuInteraction : MonoBehaviour
{
    private Button StartButton;
    private Button SettingsButton;
    private Button CreditsButton;
    private Button ExitButton;
    
private void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        this.StartButton = root.Q<Button>("StartButton");
        this.SettingsButton = root.Q<Button>("SettingsButton");
        this.CreditsButton = root.Q<Button>("CreditsButton");
        this.ExitButton = root.Q<Button>("ExitButton");
        
        this.StartButton.RegisterCallback<ClickEvent>(OnStartButtonClicked);
        this.SettingsButton.RegisterCallback<ClickEvent>(OnSettingsButtonClicked);
        this.CreditsButton.RegisterCallback<ClickEvent>(OnCreditsButtonClicked);
        this.ExitButton.RegisterCallback<ClickEvent>(OnExitButtonClicked);
    }

    private void OnStartButtonClicked(ClickEvent evt)
    {
        Debug.Log("Start Button Clicked");
    }
    
    private void OnSettingsButtonClicked(ClickEvent evt)
    {
        Debug.Log("Settings Button Clicked");
    }
    
    private void OnCreditsButtonClicked(ClickEvent evt)
    {
        Debug.Log("Credits Button Clicked");
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
