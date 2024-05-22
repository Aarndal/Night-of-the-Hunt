using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private GetInput myInput;  //Get Input through input system
    private Rigidbody2D myRigid;

    [Tooltip("Normal walk speed")]
    [SerializeField] private float normalSpeed;

    [Space(5)]
    [Tooltip("Sprint speed")]
    [SerializeField] private float sprintSpeed;

    #region Stamina

    [Space(5)]
    [Tooltip("How much stamina the player has")]
    [SerializeField] private float stamina;

    [Space(5)]
    [Tooltip("Limiter of max stamina ( player cant have more than maxStamina")]
    [SerializeField] private float maxStamina;

    [Space(5)]
    [Tooltip("How fast you want to decrease the stamina while sprinting")]
    [SerializeField] private float decreaseStamina;

    [Space(5)]
    [Tooltip("How fast you want to increase the stamina after sprinting")]
    [SerializeField] private float increaseStamina;
    #endregion


    private void Start()
    {
        myInput = GetComponent<GetInput>();
        myRigid = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        if (myInput.getInput == true)
        {
            Walk();
        }
    }

    /// <summary>
    /// Move Rigidbody through velocity that is manipulated by the input of the player   /    If Player is sprinting -> stamina decreases and player can sprint until stamina reached 0
    /// </summary>
    private void Walk()
    {
        Vector2 moveDirection = new Vector2(myInput.movement.x, myInput.movement.y);

        if (myInput.isSprinting == false || stamina <= 0.0f)
        {           
            myInput.isSprinting = false; // if its not set false -> player can sprint all the time

            moveDirection = transform.right * myInput.movement.x + transform.up * myInput.movement.y;
            myRigid.velocity = moveDirection * normalSpeed * Time.deltaTime;


            IncreaseStamina();            
        }

        if (myInput.isSprinting == true && stamina > 0.0f)
        {
            moveDirection = transform.right * myInput.movement.x + transform.up * myInput.movement.y;
            myRigid.velocity = moveDirection * sprintSpeed * Time.deltaTime;

            DecreaseStamina();          
        }

    }

    /// <summary>
    /// increase stamina while walking
    /// </summary>
    private void IncreaseStamina()
    {
        stamina = Mathf.Clamp(stamina + (increaseStamina * Time.deltaTime), 0.0f, maxStamina); 
    }


    /// <summary>
    /// decrease stamina while sprinting
    /// </summary>
    private void DecreaseStamina()
    {
        stamina = Mathf.Clamp(stamina - (decreaseStamina * Time.deltaTime), 0.0f, maxStamina); 
    }
}
