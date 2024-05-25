using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wine : MonoBehaviour
{
    public static event Action myEvent; // starts event that increase the stamina of the player 

    [Tooltip("is the index ( UI ) of the wine")]
    [SerializeField] private TextMeshProUGUI myText;

    [Tooltip("How many wines the player can drink")]
    [SerializeField] private int wineIndex;
    
    private GetInput myInput;

    private void Start()
    {
        
        
        myInput = GetComponent<GetInput>();
        myText.text += wineIndex;
    }
    private void FixedUpdate()
    {
        if(myInput.isDrinking == true && wineIndex > 0)
        { 
            Drink();
        }
    }


    private void Drink()
    {
        wineIndex--;

        myText.text = "";
        myText.text += wineIndex;

        myEvent?.Invoke();
    }
}
