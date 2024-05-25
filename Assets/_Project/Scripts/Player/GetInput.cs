using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GetInput : MonoBehaviour
{
    public Vector2 movement;  // Movement script

    public bool getInput = false;
     
    public bool isSprinting = false;  // Movement script

    public bool isShooting = false;  // Shoot script

    public bool isDrinking = false;

    private void Start()
    {
        PlayerInput playerInput =  GetComponent<PlayerInput>();

        playerInput.actions["Walk"].performed += OnMove;
        
        playerInput.actions["Sprint"].started += ctx => this.isSprinting = true;
        playerInput.actions["Sprint"].canceled += ctx => this.isSprinting = false;
        playerInput.actions["Shoot"].started += ctx => this.isShooting = true;
        playerInput.actions["Shoot"].canceled += ctx => this.isShooting = false;
        playerInput.actions["Drink"].started += ctx => this.isDrinking = true;
        playerInput.actions["Drink"].canceled += ctx => this.isDrinking = false;
    }

    public void OnMove(InputAction.CallbackContext _context)
    {
        movement = _context.ReadValue<Vector2>();

        this.getInput = this.movement != Vector2.zero;
    }
}
