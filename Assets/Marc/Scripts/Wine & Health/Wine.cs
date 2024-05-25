using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wine : MonoBehaviour
{
    public static event Action RefreshStaminaEvent; // starts event that increase the stamina of the player 

    [Tooltip("is the index ( UI ) of the wine")]
    [SerializeField] private TextMeshProUGUI myText;

    [Tooltip("How many wines the player can drink")]
    [SerializeField] private int RemainingWine;
    
    private GetInput myInput;

    private void Start()
    {
        myInput = GetComponent<GetInput>();
        this.myText.text = Convert.ToString(this.RemainingWine);
        
        this.myInput.DrinkEvent += Drink;
    }

    private void Drink()
    {
        if (this.RemainingWine <= 0) return;
        
        this.RemainingWine--;

        this.myText.text = Convert.ToString(this.RemainingWine);
        RefreshStaminaEvent?.Invoke();
    }
}
