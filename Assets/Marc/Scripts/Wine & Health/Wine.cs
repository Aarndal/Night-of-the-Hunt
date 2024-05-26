using System;
using UnityEngine;

public class Wine : MonoBehaviour
{
    public static event Action RefreshStaminaEvent; // starts event that increase the stamina of the player 

    [Tooltip("How many wines the player can drink")]
    [SerializeField] private int RemainingWine;
    
    private GetInput myInput;

    private void Start()
    {
        myInput = GetComponent<GetInput>();
        
        this.myInput.DrinkEvent += Drink;
    }

    private void Drink()
    {
        if (this.RemainingWine <= 0) return;
        
        this.RemainingWine--;

        RefreshStaminaEvent?.Invoke();
    }
}
