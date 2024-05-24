using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class Movement : MonoBehaviour
{
    [SerializeField] private Sprite[] CharacterSprites = new Sprite[4];

    private GetInput myInput; //Get Input through input system
    private Rigidbody2D myRigid; // Rigidbody of player 


    [Tooltip("Normal walk speed")] [SerializeField]
    private float normalSpeed;

    [Space(5)] [Tooltip("Sprint speed")] [SerializeField]
    private float sprintSpeed;

    #region Stamina

    [Space(5)] [Tooltip("How much stamina the player has")] [SerializeField]
    private float stamina;

    [Space(5)] [Tooltip("Limiter of max stamina ( player cant have more than maxStamina")] [SerializeField]
    private float maxStamina;

    [Space(5)] [Tooltip("How fast you want to decrease the stamina while sprinting")] [SerializeField]
    private float decreaseStamina;

    private float IncreaseStaminaStanding = 2;
    private float IncreaseStaminaWalking = 3;
    
    [Space(5)] [Tooltip("How fast you want to increase the stamina after sprinting")] [SerializeField]
    private float IncreaseStaminaFactor;

    [Space(5)] [Tooltip("How much stamina the wine regenerate")] [SerializeField]
    private float wineInfluence;



    [Space(5)] [Tooltip("Stamina circle")] [SerializeField]
    private Image myImage;

    #endregion

    [SerializeField] private float RotationSpeed = 5;
    [SerializeField] private float Amplitude = 3f;


    private void Start()
    {
        myInput = GetComponent<GetInput>();
        myRigid = GetComponent<Rigidbody2D>();

        Wine.myEvent += GetStamina;
    }

    private void FixedUpdate()
    {
        if (myInput.getInput) Walk();
        else IncreaseStamina(this.IncreaseStaminaStanding * this.IncreaseStaminaFactor);
    }

    /// <summary>
    /// Move Rigidbody through velocity that is manipulated by the input of the player   /    If Player is sprinting -> stamina decreases and player can sprint until stamina reached 0
    /// </summary>
    private void Walk()
    {
        Vector2 moveDirection = new Vector2(myInput.movement.x, myInput.movement.y);
        this.RotationSpeed = 5;
        
        GetComponent<SpriteRenderer>().sprite = moveDirection.y switch
        {
            > 0 => this.CharacterSprites[1],
            < 0 => this.CharacterSprites[0],
            0 when moveDirection.x > 0 => this.CharacterSprites[2],
            0 when moveDirection.x < 0 => this.CharacterSprites[3],
            _ => GetComponent<SpriteRenderer>().sprite
        };

        moveDirection = Vector2.right * myInput.movement.x + Vector2.up * myInput.movement.y;
        
        if (!myInput.isSprinting || stamina <= 0.0f)
        {
            myInput.isSprinting = false; // if its not set false -> player can sprint all the time

            myRigid.velocity = moveDirection * (this.normalSpeed * Time.deltaTime);
        }

        if (myInput.isSprinting && stamina > 0.0f)
        {
            this.RotationSpeed = 10;

            myRigid.velocity = moveDirection * (this.sprintSpeed * Time.deltaTime);
        }

        if (this.myInput.isSprinting) DecreaseStamina();
        else IncreaseStamina(this.IncreaseStaminaWalking * this.IncreaseStaminaFactor);

        // The Rotation Animation
        float rotation = Mathf.Sin(Time.time * this.RotationSpeed) * this.Amplitude;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }



    /// <summary>
    /// increase stamina while walking or while standing ( regenerate stamina while standing is possible cause myinput.getInput is after fist input never false again ( it is not supposed to be like this, but not relevant ))
    /// </summary>
    private void IncreaseStamina(float increaseStamina)
    {
        stamina = Mathf.Clamp(stamina + (increaseStamina * Time.deltaTime), 0.0f, maxStamina);
        this.myImage.fillAmount = (1 / this.maxStamina) * this.stamina;
    }



    /// <summary>
    /// decrease stamina while sprinting
    /// </summary>
    private void DecreaseStamina()
    {
        stamina = Mathf.Clamp(stamina - (decreaseStamina * Time.deltaTime), 0.0f, maxStamina);
        this.myImage.fillAmount = (1 / this.maxStamina) * this.stamina;
    }

    private void GetStamina()
    {
        stamina += wineInfluence;
    }
}