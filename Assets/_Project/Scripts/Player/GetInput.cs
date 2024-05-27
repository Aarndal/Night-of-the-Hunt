using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GetInput : MonoBehaviour
{
    public Vector2 movement;  // Movement script
    public Vector2 aim; 

    public bool getInput = false;
     
    public bool isSprinting = false;  // Movement script

    public event Action ShootEvent;
    public event Action DrinkEvent;
    
    public event Action DropMeatPieEvent;

    private void Start()
    {
        PlayerInput playerInput =  GetComponent<PlayerInput>();

        playerInput.actions["Walk"].performed += OnMove;
        playerInput.actions["Aim"].performed += OnAim;
        playerInput.actions["Aim"].canceled += ctx => { this.aim = Vector2.zero; };
        
        playerInput.actions["Sprint"].started += ctx => this.isSprinting = true;
        playerInput.actions["Sprint"].canceled += ctx => this.isSprinting = false;
        
        playerInput.actions["Shoot"].started += ctx => this.ShootEvent?.Invoke();
        playerInput.actions["Drink"].started += ctx => this.DrinkEvent?.Invoke();
        playerInput.actions["DropMeatPie"].started += ctx => this.DropMeatPieEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext _context)
    {
        movement = _context.ReadValue<Vector2>();

        this.getInput = this.movement != Vector2.zero;
    }
    
    public void OnAim(InputAction.CallbackContext _context)
    {
        this.aim = _context.ReadValue<Vector2>();
    }
}
